using System;
using System.Threading.Tasks;
using FastAuth;
using MediShare.Models;
using Microsoft.AspNetCore.Mvc;
using Server;
using Server2;

namespace MediShare.Controllers.Auth
{
    public class LoginController : BaseController
    {

        public IActionResult Index()
        {
            return View("~/Views/Auth/Login.cshtml");
        }
        

        // [HttpPost, AllowAnonymous]
        public async Task<IActionResult> LoginNow(LoginModel login_model,string email, string password)    
        {
            Console.WriteLine("LoginNow is called");
            string passwordHashed = Password.ComputeHash(password);
            var login_Data = await DAL.ExecuteReaderAsync<LoginModel>(
                @"SELECT user_id,email, password,
                is_verified,role 
                FROM users
                WHERE email = @email",
                new string[,]{
                    {"@email",  email}

                }
            );
            

            
            Console.WriteLine("User Found: " + login_Data.Count);
            
            if(login_Data.Count>0){
                if(login_Data[0].email == email){
                    if(login_Data[0].is_verified == "yes"){
                        if(Password.Verify(password.Trim(), login_Data[0].password)){
                            CreateAuthenticationTicket(login_Data[0]);
                            if(login_Data[0].role == "admin"){
                                return Ok(200);
                            }
                            else{
                                return Ok(201);
                            }
                        }
                        else {
                            return Ok(500);
                        }
                    }
                    else {
                        return Ok(400);
                    }
                }   
            }
            else{
                return Ok(300);
            }

            return Content("ok");


        }
    }
}