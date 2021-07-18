using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using FastAuth;
using Server;
using Server2;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using Microsoft.AspNetCore.Http;
using mainServer.Models;
using Payment;




namespace mainServer.Controllers.Pages
{

    public class PackageModelSubPrice
    {
        public string price{get;set;}
    }


    public class Project_Limit_Val{
        public int val_limit{get;set;}
    }

    public class BuyNoworAddtoCartModel
    {
        public string product_id {get; set;}
        public string user_id {get; set;}
        public int price {get; set;}
        public int  quantity {get; set;}
        public string file_name {get; set;}
        public string product_name {get; set;}
    }
    

    public class AddressModel
    {
        public string user_address {get; set;}
        public string phone {get; set;}
    }


    public class PaymentController : BaseController
    {
        public async Task<IActionResult> DemoPayment2()
        {

            string user_id = GetUserID();

            if(user_id == null){
                return Redirect(Keys.WebSiteDomain + "/Login");
            }

            var res = await DAL.ExecuteReaderAsync<BuyNoworAddtoCartModel>(
                @"SELECT product_name,quantity,price,product_id,file_name,user_id 
                FROM cart WHERE user_id=@user_id",
                new string[,]{
                    {"@user_id", user_id}
                }
            );


            int TotalPrice = 0;

            for(int i=0; i<res.Count; i++){
                TotalPrice += res[i].price;
            }
            


            NameValueCollection PostData = new NameValueCollection();

            PostData.Add("total_amount", TotalPrice.ToString());
            PostData.Add("tran_id", "TESTASPNET1234");
            PostData.Add("success_url", Keys.WebSiteDomain+"/Payment/DemoPaymentSuccessResponse2");
            PostData.Add("fail_url", Keys.WebSiteDomain+"/Payment/DemoPaymentFailureResponse"); // "Fail.aspx" page needs to be created
            PostData.Add("cancel_url", Keys.WebSiteDomain+"/"); // "Cancel.aspx" page needs to be created
            PostData.Add("version", "3.00");
            PostData.Add("cus_name", "ABC XY");
            PostData.Add("cus_email", "abc.xyz@mail.co");
            PostData.Add("cus_add1", "Address Line On");
            PostData.Add("cus_add2", "Address Line Tw");
            PostData.Add("cus_city", "City Nam");
            PostData.Add("cus_state", "State Nam");
            PostData.Add("cus_postcode", "Post Cod");
            PostData.Add("cus_country", "Countr");
            PostData.Add("cus_phone", "0111111111");
            PostData.Add("cus_fax", "0171111111");
            PostData.Add("ship_name", "ABC XY");
            PostData.Add("ship_add1", "Address Line On");
            PostData.Add("ship_add2", "Address Line Tw");
            PostData.Add("ship_city", "City Nam");
            PostData.Add("ship_state", "State Nam");
            PostData.Add("ship_postcode", "Post Cod");
            PostData.Add("ship_country", "Countr");
            PostData.Add("value_a", user_id);
            PostData.Add("value_b", "sadasd");
            PostData.Add("value_c", "shshshs");
            PostData.Add("value_d", "aaaaaa");
            PostData.Add("shipping_method", "NO");
            PostData.Add("num_of_item", "1");
            PostData.Add("product_name", "aaaa");
            PostData.Add("product_profile", "general");
            PostData.Add("product_category", "Demo");

            SSLCommerz sslcz = new SSLCommerz("openc604893a593fe6", "openc604893a593fe6@ssl", true);
            String response = sslcz.InitiateTransaction(PostData);

            return Redirect(response);

        }


        public async Task<IActionResult> BuyNoworAddtoCart(string product_id, int quantity, string what)
        {
            

            Console.WriteLine(product_id+"    "+quantity);
            
            var res = await DAL.ExecuteReaderAsync<ProductModel>(
                    @"SELECT product_id,product_name,category,
                    quantity,upload_date,number_of_orders,
                    status,user_shop_id,per_unit_price,file_name
                    FROM product_list WHERE product_id = @product_id 
                    ",
                    new string[,]{
                        {"@product_id",  product_id}
                    }
            );

            string user_id = GetUserID();
            if(user_id == null){
                return Redirect("/Login");
            }
            int price = (res[0].per_unit_price * quantity);

            var ins = await DAL.ExecuteNonQueryAsync(
                @"INSERT INTO cart 
                (
                    user_id,
                    product_id,
                    price,
                    file_name,
                    quantity,
                    product_name
                )
                VALUES
                (
                    @user_id,
                    @product_id,
                    "+price+@",
                    @file_name,
                    "+quantity+@",
                    @product_name
                )",
                new string[,]{
                    {"@user_id", user_id },
                    {"@product_id", res[0].product_id},
                    {"@file_name", res[0].file_name},
                    {"@product_name", res[0].product_name}
                }
            );

            return Redirect("/ProductPage?product_id="+product_id);

        }

        public async Task<ActionResult<List<BuyNoworAddtoCartModel>>> GetCartList()
        {
            

            string user_id = GetUserID();
            if(user_id == null){
                return Redirect("/Login");
            }

            var res = await DAL.ExecuteReaderAsync<BuyNoworAddtoCartModel>(
                @"SELECT product_name,quantity,price,product_id,file_name,user_id 
                FROM cart WHERE user_id=@user_id",
                new string[,]{
                    {"@user_id", user_id}
                }
            );

            return res;
        }

        public async Task<ActionResult<List<AddressModel>>> GetAddressandPhone()
        {
            

            string user_id = GetUserID();
            if(user_id == null){
                return Redirect("/Login");
            }

            var addrss = await DAL.ExecuteReaderAsync<AddressModel>(
                @"SELECT user_address,phone FROM users 
                WHERE user_id=@user_id",
                new string[,]{
                    {"@user_id", user_id}
                }
            );

            return addrss;

        }

        
        public async Task<IActionResult> ClearCart()
        {

            string user_id = GetUserID();
            if(user_id == null){
                return Redirect("/Login");
            }

            var ins = await DAL.ExecuteNonQueryAsync(
                @"DELETE FROM cart WHERE user_id=@user_id",
                new string[,]{
                    {"@user_id", user_id}
                }
            );


            return Redirect("/Home");
        }




        public async Task<IActionResult> DemoPaymentSuccessResponse2(ValidatePaymentwithIPN checkerModel)
        {

            if(checkerModel.value_a == null) return Content("Error");

            string user_id = checkerModel.value_a;

            

            var ress = await DAL.ExecuteReaderAsync<BuyNoworAddtoCartModel>(
                @"SELECT product_name,quantity,price,product_id,file_name,user_id 
                FROM cart WHERE user_id=@user_id",
                new string[,]{
                    {"@user_id", user_id}
                }
            );


            Console.WriteLine(ress[0].product_name);


            for(int i=0;i<ress.Count; i++){
                Console.WriteLine(i);

                var ins2 = await DAL.ExecuteNonQueryAsync(
                    @"INSERT INTO orders
                    (
                        product_id,
                        product_name,
                        quantity,
                        status,
                        order_date,
                        user_id
                    )
                    VALUES
                    (
                        @product_id,
                        @product_name,
                        "+ress[0].quantity+@",
                        @status,
                        @order_date,
                        @user_id
                    )",
                    new string[,]{
                        {"@user_id", user_id},
                        {"@product_id", ress[i].product_id},
                        {"@product_name", ress[i].product_name},
                        {"@status", "Payment Completed"},
                        {"@order_date", MySqlUtility.ConvertTo_MySqlDate(DateTime.Now)}
                    }
                );
            }



            var inss = await DAL.ExecuteNonQueryAsync(
                @"DELETE FROM cart WHERE user_id=@user_id",
                new string[,]{
                    {"@user_id", user_id}
                }
            );


            return View("~/wwwroot/Extensions/PaymentSuccessView.cshtml");
        }


        public IActionResult DemoPaymentFailureResponse()
        {
            Console.WriteLine("Payment unsuccessful");

            return View("~/wwwroot/Extensions/PaymentFailureView.cshtml");
        }

    }







    public class ValidatePaymentwithIPN
    {
        public string status { get; set; }
        public string tran_date { get; set; }
        public string tran_id { get; set; }
        public string val_id { get; set; }
        public string amount { get; set; }
        public string store_amount { get; set; }
        public string currency { get; set; }
        public string bank_tran_id { get; set; }
        public string card_type { get; set; }
        public string card_no { get; set; }
        public string card_issuer { get; set; }


        
        public string card_brand { get; set; }
        public string card_issuer_country { get; set; }
        public string card_issuer_country_code { get; set; }
        public string currency_type { get; set; }
        public string currency_amount { get; set; }



        public string value_a { get; set; }
        public string value_b { get; set; }
        public string value_c { get; set; }
        public string value_d { get; set; }
        public string risk_title { get; set; }
        public string risk_level { get; set; }
        public string verify_sign { get; set; }
        public string verify_key { get; set; }

    }
}