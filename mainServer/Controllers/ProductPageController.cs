using System;
using MediShare.Models;
using Microsoft.AspNetCore.Mvc;
using Server2;
using System.Threading.Tasks;
using Server;
using System.Collections.Generic;
using mainServer.Models;

namespace mainServer.Controllers
{
    public class LoginandProductPage
    {
        public string email{get; set;}
        public string password{get;set;}
        public string product_name {get; set;}
        public string file_name {get; set;}
        public int per_unit_price {get; set;}
        public string product_id {get; set;}
    }


    public class ProductPageController : BaseController
    {
        public async Task<IActionResult> Index(string product_id)
        {
            string email = GetUserEMAIL();
            
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
            
            if(res.Count == 0){
                return Redirect("~/");
            }
            
            LoginandProductPage loginModel = new LoginandProductPage();
            loginModel.email = email;
            if(email == null) loginModel.password = "n";

            loginModel.product_name = res[0].product_name;
            loginModel.per_unit_price = res[0].per_unit_price;
            loginModel.file_name = res[0].file_name;
            loginModel.product_id = product_id;


            return View("~/Views/HomePage/ProductPage.cshtml",loginModel);
        }



        public async Task<ActionResult<List<ProductModel>>> ProductPageItem(string product_id)
        {
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

                return res;
        }
    }
}