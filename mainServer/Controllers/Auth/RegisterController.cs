using System;
using System.Threading.Tasks;
using FastAuth;
using Mail;
using Microsoft.AspNetCore.Mvc;
using Server;

namespace MediShare.Controllers.Auth
{
    public class RegisterController : Controller
    {

        public IActionResult Index()
        {
            return View("~/Views/Auth/Register.cshtml");
        }

        public async Task<IActionResult> registration_data(string first_name,string last_name,string email,string password)
        {
            string user_PasswordHashed =  Password.ComputeHash(password);
            string verify_code = FAuth.GenerateID(16);
            string user_id = FAuth.GenerateID(16);

            //Console.WriteLine(verify_Code);
            //  return Content("OK");
            Console.WriteLine(email+"  "+ password);


            //new opencloud DB entry
            bool email_Check  = await DAL.IsExist(
                @"SELECT * FROM users 
                WHERE email = @email",
                new string [,]{
                    {"@email", email}
                }
            );

            if(email_Check) {
                // return Content("Email already in use!");
                return Ok(404);
            }
            else {
                bool usr_data = await DAL.ExecuteNonQueryAsync(
                    @"INSERT INTO users ( 
                        user_id,
                        email,
                        password,
                        old_password,
                        first_name,
                        last_name,
                        is_verified,
                        verify_code,
                        created,
                        role,
                        phone,
                        user_address
                    ) 
                    VALUES (
                        @user_id, 
                        @email,
                        @password,
                        @old_password,
                        @first_name,
                        @last_name,
                        @is_verified,
                        @verify_code,
                        @created,
                        'client',
                        'N/A',
                        'N/A'
                    )",
                    new string[,] {
                        { "@user_id", user_id },
                        { "@email", email },
                        { "@password", user_PasswordHashed },
                        { "@old_password", user_PasswordHashed },
                        { "@first_name", first_name },
                        { "@last_name", last_name },
                        { "@is_verified", "yes" },
                        { "@verify_code", verify_code},
                        { "@created", MySqlUtility.ConvertTo_MySqlDate(DateTime.Now) }
                    }
                );
                // MailClient.SendVerifyEmail(email, verify_code);
                return Ok(200);
                // return View("~/wwwroot/Extensions/RegistrationView.cshtml");

            }
        }

        public IActionResult RegistrationSuccess()
        {
            return View("~/wwwroot/Extensions/RegistrationView.cshtml");
        }
    }
}