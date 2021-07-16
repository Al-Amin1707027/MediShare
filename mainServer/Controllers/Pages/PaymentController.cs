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


    public class PaymentController : BaseController
    {
        public async Task<IActionResult> DemoPayment2(string product_id, string what)
        {
            

            



            // string client_id = GetUserID();

            // if(client_id == null){
            //     return Redirect(Keys.WebSiteDomain + "/Login");
            // }

            // var res = await DAL.ExecuteReaderAsync<ProductModel>(
            //         @"SELECT product_id,product_name,category,
            //         quantity,upload_date,number_of_orders,
            //         status,user_shop_id,per_unit_price,file_name
            //         FROM product_list WHERE product_id = @product_id 
            //         ",
            //         new string[,]{
            //             {"@product_id",  product_id}
            //         }
            //     );

            // Console.WriteLine(packageDataPrice[0].price);
            


            // NameValueCollection PostData = new NameValueCollection();

            // PostData.Add("total_amount", res[0].per_unit_price);
            // PostData.Add("tran_id", "TESTASPNET1234");
            // PostData.Add("success_url", Keys.WebSiteDomain+"/Payment/DemoPaymentSuccessResponse2");
            // PostData.Add("fail_url", Keys.WebSiteDomain+"/Payment/DemoPaymentFailureResponse"); // "Fail.aspx" page needs to be created
            // PostData.Add("cancel_url", Keys.WebSiteDomain+"/"); // "Cancel.aspx" page needs to be created
            // PostData.Add("version", "3.00");
            // PostData.Add("cus_name", "ABC XY");
            // PostData.Add("cus_email", "abc.xyz@mail.co");
            // PostData.Add("cus_add1", "Address Line On");
            // PostData.Add("cus_add2", "Address Line Tw");
            // PostData.Add("cus_city", "City Nam");
            // PostData.Add("cus_state", "State Nam");
            // PostData.Add("cus_postcode", "Post Cod");
            // PostData.Add("cus_country", "Countr");
            // PostData.Add("cus_phone", "0111111111");
            // PostData.Add("cus_fax", "0171111111");
            // PostData.Add("ship_name", "ABC XY");
            // PostData.Add("ship_add1", "Address Line On");
            // PostData.Add("ship_add2", "Address Line Tw");
            // PostData.Add("ship_city", "City Nam");
            // PostData.Add("ship_state", "State Nam");
            // PostData.Add("ship_postcode", "Post Cod");
            // PostData.Add("ship_country", "Countr");
            // PostData.Add("value_a", product_id);
            // PostData.Add("value_b", res[0].product_name);
            // PostData.Add("value_c", res[0].per_unit_price);
            // PostData.Add("value_d", res[0].category);
            // PostData.Add("shipping_method", "NO");
            // PostData.Add("num_of_item", "1");
            // PostData.Add("product_name", plan);
            // PostData.Add("product_profile", "general");
            // PostData.Add("product_category", "Demo");

            // SSLCommerz sslcz = new SSLCommerz("openc604893a593fe6", "openc604893a593fe6@ssl", true);
            // String response = sslcz.InitiateTransaction(PostData);

            // return Redirect(response);

            return Ok(200);

        }


        public async Task<IActionResult> BuyNoworAddtoCart(string product_id, int quantity, string what)
        {
            // if(what == "buynow"){
            //     var res = await DAL.ExecuteReaderAsync<ProductModel>(
            //         @"SELECT product_id,product_name,category,
            //         quantity,upload_date,number_of_orders,
            //         status,user_shop_id,per_unit_price,file_name
            //         FROM product_list WHERE product_id = @product_id 
            //         ",
            //         new string[,]{
            //             {"@product_id",  product_id}
            //         }
            //     );
            //     string user_id = GetUserID();

            //     var ins = await DAL.ExecuteNonQueryAsync(
            //         @"INSERT INTO ",
            //         new string[,]{
            //             {}
            //         }
            //     );


            //     BuyNoworAddtoCartModel cartModel = new BuyNoworAddtoCartModel();
            //     cartModel.product_name = res[0].product_name;
            //     cartModel.quantity = quantity;
            //     cartModel.file_name = res[0].file_name;
            //     cartModel.price = (quantity * res[0].per_unit_price)

            //     return cartModel;
            // }

            // else{
                
            // }

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




        // public async Task<IActionResult> DemoPaymentSuccessResponse2(ValidatePaymentwithIPN checkerModel)
        // {

        //     if(checkerModel.value_a == null) return Content("Error");
            
        
        

        //     var packageData = await DAL.ExecuteReaderAsync<PackageModelSub>(
        //         @"SELECT 
        //         value,exp_time,auto_renew,package_id
        //         FROM packages WHERE package_name=@package_name",
        //         new string[,]{
        //             {"@package_name", checkerModel.value_a}
        //         }
        //     );
 
            
        


        //     if(checkerModel.value_c == "new"){
        //         bool res = await DAL.ExecuteNonQueryAsync(
        //         @"INSERT INTO orders (
        //             product_id,
        //             product_name,
        //             quantity,
        //             category,
        //             status,
        //             order_date
                    
        //         ) 
        //         VALUES(
        //             @product_id,
        //             @product_name,
        //             @quantity,
        //             @category,
        //             @status,
        //             @order_date
                    
        //         )
        //         ",
        //         new string[,]{
        //             {"@project_id",project_id},
        //             {"@project_name", checkerModel.value_b},
        //             {"@client_id",checkerModel.value_d},
        //             {"@start_date", MySqlUtility.ConvertTo_MySqlDate(DateTime.Now)},
        //             {"@expire_date", MySqlUtility.ConvertTo_MySqlDate(answer)},
        //             {"@validity", packageData[0].exp_time}
        //         }
        //         );
        //     }


        //     Console.WriteLine("Payment Successful");

        //     Console.WriteLine(checkerModel.status);
        //     Console.WriteLine(checkerModel.value_a);
           

        //     return View("~/wwwroot/Extensions/PaymentSuccessView.cshtml");
        // }


        // public IActionResult DemoPaymentFailureResponse()
        // {
        //     Console.WriteLine("Payment unsuccessful");

        //     return View("~/wwwroot/Extensions/PaymentFailureView.cshtml");
        // }

        // public IActionResult DemoPayment3(string plan, string project_name,string what){
        //     Console.WriteLine(plan);
        //     Console.WriteLine(project_name);
        //     Console.WriteLine(what);
        //     return Content("ok");
        // }




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













// public async Task<IActionResult> DemoPayment(string plan)
//         {
//             string client_id = GetUserID();

//             var check_already_subscribed = await DAL.ExecuteReaderAsync<SubModel>(
//                 @"SELECT subscription_id,client_id,expire_date,validity FROM subscriptions 
//                 WHERE client_id=@client_id",
//                 new string[,]{
//                     {"@client_id", client_id}
//                 }
//             );

//             if(check_already_subscribed.Count > 0) return Redirect("~/");

//             var packageDataPrice = await DAL.ExecuteReaderAsync<PackageModelSubPrice>(
//                 @"SELECT 
//                 price
//                 FROM packages WHERE package_name=@package_name",
//                 new string[,]{
//                     {"@package_name", plan}
//                 }
//             );


//             NameValueCollection PostData = new NameValueCollection();

//             PostData.Add("total_amount", packageDataPrice[0].price);
//             PostData.Add("tran_id", "TESTASPNET1234");
//             PostData.Add("success_url", "https://localhost:5001/Payment/DemoPaymentSuccessResponse");
//             PostData.Add("fail_url", "https://localhost:5001/Payment/DemoPaymentFailureResponse"); // "Fail.aspx" page needs to be created
//             PostData.Add("cancel_url", "https://localhost:5001/"); // "Cancel.aspx" page needs to be created
//             PostData.Add("version", "3.00");
//             PostData.Add("cus_name", "ABC XY");
//             PostData.Add("cus_email", "abc.xyz@mail.co");
//             PostData.Add("cus_add1", "Address Line On");
//             PostData.Add("cus_add2", "Address Line Tw");
//             PostData.Add("cus_city", "City Nam");
//             PostData.Add("cus_state", "State Nam");
//             PostData.Add("cus_postcode", "Post Cod");
//             PostData.Add("cus_country", "Countr");
//             PostData.Add("cus_phone", "0111111111");
//             PostData.Add("cus_fax", "0171111111");
//             PostData.Add("ship_name", "ABC XY");
//             PostData.Add("ship_add1", "Address Line On");
//             PostData.Add("ship_add2", "Address Line Tw");
//             PostData.Add("ship_city", "City Nam");
//             PostData.Add("ship_state", "State Nam");
//             PostData.Add("ship_postcode", "Post Cod");
//             PostData.Add("ship_country", "Countr");
//             PostData.Add("value_a", plan);
//             PostData.Add("value_b", "ref00");
//             PostData.Add("value_c", "ref00");
//             PostData.Add("value_d", "ref00");
//             PostData.Add("shipping_method", "NO");
//             PostData.Add("num_of_item", "1");
//             PostData.Add("product_name", plan);
//             PostData.Add("product_profile", "general");
//             PostData.Add("product_category", "Demo");

//             SSLCommerz sslcz = new SSLCommerz("openc604893a593fe6", "openc604893a593fe6@ssl", true);
//             String response = sslcz.InitiateTransaction(PostData);

//             return Redirect(response);

//         }

//         public async Task<IActionResult> DemoPaymentSuccessResponse(ValidatePaymentwithIPN checkerModel)
//         {

//             if(checkerModel.value_a == null) return Content("Error");
//             // Store record in Subscriptions table that this user is subscribed to this plan  
//             string Subscription_id = FAuth.GenerateID(13);
//             string client_id = GetUserID();
//             //plan = "Ultra";

            
//             Console.WriteLine(client_id);

//             var packageData = await DAL.ExecuteReaderAsync<PackageModelSub>(
//                 @"SELECT 
//                 value,exp_time,auto_renew,package_id
//                 FROM packages WHERE package_name=@package_name",
//                 new string[,]{
//                     {"@package_name", checkerModel.value_a}
//                 }
//             );

//             int validity_days = Convert.ToInt32(packageData[0].exp_time);
//             // Console.WriteLine(validity_days);
//             var time = MySqlUtility.ConvertTo_MySqlDate(DateTime.Now);
//             System.DateTime today = System.DateTime.Now;
//             System.TimeSpan duration = new System.TimeSpan(validity_days, 0, 0, 0);
//             System.DateTime answer = today.Add(duration);
//             // Console.WriteLine(today);
//             // Console.WriteLine(MySqlUtility.ConvertTo_MySqlDate(answer));
//             var x = MySqlUtility.ConvertTo_MySqlDate(answer);
//             Console.WriteLine(x.GetType());
           


//             bool res = await DAL.ExecuteNonQueryAsync(
//                 @"INSERT INTO subscriptions (
//                     subscription_id,
//                     client_id,
//                     start_date,
//                     expire_date,
//                     package_id,
//                     validity
//                 ) 
//                 VALUES(
//                     @subscription_id,
//                     @client_id,
//                     @start_date,
//                     @expire_date,
//                     "+packageData[0].package_id+@",
//                     @validity
//                 )
//                 ",
//                 new string[,]{
//                     {"@subscription_id",Subscription_id},
//                     {"@client_id",client_id},
//                     {"@start_date", MySqlUtility.ConvertTo_MySqlDate(DateTime.Now)},
//                     {"@expire_date", MySqlUtility.ConvertTo_MySqlDate(answer)},
//                     {"@validity", packageData[0].exp_time}
//                 }
//             );

//             Console.WriteLine("Payment Successful");

//             Console.WriteLine(checkerModel.status);
//             Console.WriteLine(checkerModel.value_a);
           

//             return View("~/wwwroot/Extensions/PaymentSuccessView.cshtml");
//         }