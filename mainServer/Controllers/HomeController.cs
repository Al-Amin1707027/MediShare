using System;
using MediShare.Models;
using Microsoft.AspNetCore.Mvc;
using Server2;

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
        
    }
}