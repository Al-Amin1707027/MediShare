using System;
using MediShare.Models;
using Microsoft.AspNetCore.Mvc;
using Server2;
using System.Threading.Tasks;
using Server;
using System.Collections.Generic;
using mainServer.Models;
using mainServer.Controllers;
using mainServer.Controllers.Pages;


namespace mainServer.Controllers
{
    public class CategoricalController : BaseController
    {
        public IActionResult Index(string category){
            

            string email = GetUserEMAIL();


            LoginandProductPage loginModel = new LoginandProductPage();
            loginModel.email = email;
            loginModel.product_name = category;
            if(email == null) loginModel.password = "n";


            return View("~/Views/HomePage/CategoricalPage.cshtml",loginModel);
        }

        public async Task<ActionResult<List<ProductModel>>> GetProductListbyCategory(string category)
        {
            Console.WriteLine(category);
                var res = await DAL.ExecuteReaderAsync<ProductModel>(
                    @"SELECT product_id,product_name,category,
                    quantity,upload_date,number_of_orders,
                    status,user_shop_id,per_unit_price,file_name
                    FROM product_list WHERE category = @category
                    ",
                    new string[,]{
                        {"@category", category}
                    }
                );

                return res;
        }
        
    }
}