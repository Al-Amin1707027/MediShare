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
    public class CartPageController : BaseController
    {
        public IActionResult Index()
        {
            string email = GetUserEMAIL();
            

            LoginandProductPage loginModel = new LoginandProductPage();
            loginModel.email = email;
            if(email == null) loginModel.password = "n";

            return View("~/Views/HomePage/CartPage.cshtml", loginModel);
        }
    }
}