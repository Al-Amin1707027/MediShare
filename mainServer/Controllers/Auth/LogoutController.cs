using Microsoft.AspNetCore.Mvc;
using Server2;

namespace mainServer.Controllers.Auth
{
    public class LogoutController : BaseController
    {
        public IActionResult Index() {
            Response.Cookies.Delete("auth");
            return Redirect("~/");
        }

        public async Task<IActionResult> MyName()
        {
            Console.WriteLine("this is fuck");
        }
        
    }
}