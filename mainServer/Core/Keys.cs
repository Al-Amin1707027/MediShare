using Microsoft.Extensions.Configuration; 

namespace Server2 {
    public class Keys {
        private static IConfigurationSection _configuration;  
        public static void Configure(IConfigurationSection configuration) {  
            _configuration = configuration;  
        }  
        
        public static string WebSiteDomain => _configuration["WebSiteDomain"];  
        public static string AuthSecret => _configuration["AuthSecret"];
        public static string HashPeeper => _configuration["HashPeeper"];
    }
}