using System;
using MediShare.Models;
using Microsoft.AspNetCore.Mvc;
using Server2;
using System.Threading.Tasks;
using Server;
using System.Collections.Generic;
using mainServer.Models;

namespace MediShare.Controllers
{
    public class HomeController : BaseController
    {


        public IActionResult Index(){

            string email = GetUserEMAIL();

            LoginModel loginModel = new LoginModel();
            loginModel.email = email;

            if(email == null) loginModel.password = "n";


            return View("~/Views/HomePage/index.cshtml",loginModel);
        }


        public async Task<ActionResult<List<ProductModel>>> GetProductList()
        {
                var res = await DAL.ExecuteReaderAsync<ProductModel>(
                    @"SELECT product_id,product_name,category,
                    quantity,upload_date,number_of_orders,
                    status,user_shop_id,per_unit_price,file_name
                    FROM product_list 
                    ",
                    new string[,]{

                    }
                );

                // if(res.Count == 0){
                //     return Ok
                // }

                return res;
        }
        
    }
}