namespace MediShare.Models
{
    public class LoginModel
    {
        public string email{get; set;}
        public string password{get;set;}
        public string is_verified{get;set;}
        public string user_id {get;set;}
        public string role{get;set;}
    }
}