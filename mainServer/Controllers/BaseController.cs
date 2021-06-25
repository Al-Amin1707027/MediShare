using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Collections.Generic;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System;
using System.IdentityModel.Tokens;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using MediShare.Models;

namespace Server2 {
    
    public class UserLogin {
        public string Email {get;set;}
        public string Password {get;set;}
        public string Role {get;set;}
        
    }

    
    public struct Role {  
        public const string Admin = "admin";  
        public const string Guest = "guest";
        public const string Client = "Client";   
    }  
    
    public class BaseController : Controller {
        
        public void CreateAuthenticationTicket(LoginModel user) {
            var key = Encoding.ASCII.GetBytes(Keys.AuthSecret);  
            var JWToken = new JwtSecurityToken(  
                issuer: Keys.WebSiteDomain,  
                audience: Keys.WebSiteDomain,  
                claims: GetUserClaims(user),  
                notBefore: new DateTimeOffset(DateTime.Now).DateTime,  
                expires: new DateTimeOffset(DateTime.Now.AddDays(1)).DateTime,  
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            );
            var token = new JwtSecurityTokenHandler().WriteToken(JWToken);
            //System.Console.WriteLine(token);
            //HttpContext.Session.SetString("JWToken", token);
            
            CookieOptions option = new CookieOptions(); 
            option.Expires = DateTime.Now.AddYears(1);  
            Response.Cookies.Append("auth", token, option);  
        }
        
        private List<Claim> GetUserClaims(LoginModel user) {
            List<Claim> claims = new List<Claim>();  
            Claim _claim;  
            _claim = new Claim(ClaimTypes.Name, user.email);  
            claims.Add(_claim);  
            
            // User ID
            _claim = new Claim("user_id", user.user_id);     // Put user_id in cookie
            claims.Add(_claim);
            _claim = new Claim("email", user.email);     // Put user_id in cookie
            claims.Add(_claim);
            
            // User Role
            if(user.role == "admin"){
                _claim = new Claim("Role", Role.Admin );  
                claims.Add(_claim);
            }
            else{
                _claim = new Claim("Role", Role.Client);  
                claims.Add(_claim);
            }

  
            return claims;  
        }
        
        public string GetUserID() {
            string user_id = null;
            foreach(var v in User.Claims) {
                //System.Console.WriteLine(v.Type.ToString() +" "+v.Value.ToString());
                if(v.Type.ToString() == "user_id") {
                    user_id = v.Value.ToString();
                }
            }
            return user_id;
        }
        public string GetUserEMAIL() {
            string email = null;
            foreach(var v in User.Claims) {
                // System.Console.WriteLine(v.Type.ToString() +" "+v.Value.ToString());
                if(v.Type.ToString() == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress") {
                    email = v.Value.ToString();
                }
            }

            return email;
        }
    }
}
