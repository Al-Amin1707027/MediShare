using System;
using MediShare.Models;
using Microsoft.AspNetCore.Mvc;
using Server2;
using System.Threading.Tasks;
using Server;
using System.Collections.Generic;
using mainServer.Models;
using mainServer.Controllers;

namespace MediShare.Controllers
{
    public class ProfileModel
    {
        public string email{get; set;}
        public string user_address {get; set;}
        public string phone {get; set;}
    }
    public class HomeController : BaseController
    {


        public IActionResult Index(){
            

            string email = GetUserEMAIL();
            

            LoginandProductPage loginModel = new LoginandProductPage();
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
        


        public async Task<ActionResult<List<ProductModel>>> SuggestedProducts()
        {
                var res = await DAL.ExecuteReaderAsync<ProductModel>(
                    @"SELECT product_id,product_name,category,
                    quantity,upload_date,number_of_orders,
                    status,user_shop_id,per_unit_price,file_name
                    FROM product_list LIMIT "+0+", "+3+@"
                    ",
                    new string[,]{

                    }
                );

                return res;
        }

        

        public async Task<IActionResult> AddAddress(string street, string sadarupazilla,string district,string phone)
        {
                var fulladdress = street+"<br>"+sadarupazilla+"<br>"+district;
                Console.WriteLine(phone);

                string user_id = GetUserID();
                if(user_id == null){
                    return Redirect("/Login");
                }

                var address = await DAL.ExecuteNonQueryAsync(
                    @"UPDATE users SET user_address=@fulladdress,phone=@phone  
                    WHERE user_id=@user_id",
                    new string[,]{
                        {"@user_id", user_id},
                        {"@fulladdress", fulladdress},
                        {"@phone", phone}
                    }
                );

                return Redirect("/UserDashboard");
        }

        public async Task<ActionResult<List<ProfileModel>>> ProfileData()
        {
            string user_id = GetUserID();
            if(user_id == null){
                return Redirect("/Login");
            }

            var res = await DAL.ExecuteReaderAsync<ProfileModel>(
                @"SELECT email,user_address,phone FROM users 
                WHERE user_id=@user_id",
                new string[,]{
                    {"@user_id", user_id}
                }
            );

            return res;
        }
        
    }
}