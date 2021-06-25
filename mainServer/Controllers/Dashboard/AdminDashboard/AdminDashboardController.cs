using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Server;
using Server2;

namespace mainServer.Controllers.Dashboard.AdminDashboard
{
    public class AdminDashboardController : BaseController
    {
        [Authorize(Role.Admin)]
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
            
            
            if(loginCheck){
                return View("~/Views/Dashboard/AdminDashboard/Index.cshtml");
            }
            else{
                return Redirect("/Logout");
            }
            
            // return Content("Something went wrong.sorry.");
        }
    }
}