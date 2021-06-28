using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Server;
using Server2;

namespace mainServer.Controllers.Dashboard.UserDashboard
{
    public class UserDashboardController : BaseController
    {
        public async Task<IActionResult> Index()
        {
            
            string email = GetUserEMAIL();

            bool loginCheck = await DAL.IsExist(
                @"SELECT email FROM users 
                WHERE email = @email",
                new string[,]{
                    {"@email", email}
                }
            );
            
            
            // if(loginCheck){
            //     return View("~/Views/Dashboard/UserDashboard/Index.cshtml");
            // }
            // else{
            //     return Redirect("/Logout");
            // }
            
            return View("~/Views/fileupload.cshtml");
        }
    }
}