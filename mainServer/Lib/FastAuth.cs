/* Copyright (C) 2021 Shamim Ahamed - All Rights Reserved
 * Contact: pavel123@outlook.in
 * Any modification of this file must contain the above copyright notice.
 */
using System;
using System.Text;
using System.Security.Cryptography;

namespace FastAuth {
    public static class Password {
        private static int workfactor = 12;
        
        private volatile static object hmac_lock = new object();
        private volatile static HMACSHA512 hmac;
        
        public static void Init(string key, int Workfactor = 12) {
            hmac = new HMACSHA512(Encoding.UTF8.GetBytes(key));
            workfactor = Workfactor;
        }
        
        private static string Preprocess(string password) {
            byte[] sha_buff;
            lock(hmac_lock) {
                sha_buff = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
            return Encoding.UTF8.GetString(sha_buff);
        }
        
        public static string ComputeHash(string password) {
            return BCrypt.Net.BCrypt.HashPassword(Preprocess(password), workfactor);
        }
        
        public static bool Verify(string submitted, string hashed) {
            return BCrypt.Net.BCrypt.Verify(Preprocess(submitted), hashed);
        }
    }
    
    
    public static class FAuth {
        private static int token_lifetime;
        private static readonly DateTime ref_date = new DateTime(2000, 1, 1, 0, 0, 0);
        
        private static volatile object hmac_lock = new object();
        private static volatile HMACSHA256 hmac;
        
        public static void Init(string Key, int TokenLifetime_inSecond = 21600) {
            byte[] key = Encoding.UTF8.GetBytes(Key);
            token_lifetime = TokenLifetime_inSecond;
            hmac = new HMACSHA256(key);
        }
        
        public static string GetToken(string payload) {
            string payload_base64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(payload));
            string iat = ((int)((DateTime.Now - ref_date).TotalSeconds)).ToString();

            byte[] body_arr = Encoding.UTF8.GetBytes(payload_base64 + iat);
            byte[] hash;
            lock(hmac_lock) {
                hash = hmac.ComputeHash(body_arr);
            }
            
            string hash_base64 = Convert.ToBase64String(hash);
            return payload_base64 + "." + iat + "." + hash_base64;
        }
        
        public static bool Validate(string token, out string payload) {
            payload = string.Empty;
            if(token == null) return false;
            
            var arr = token.Split('.');
            if(arr.Length != 3) return false;
            
            string body = arr[0] + arr[1];
            byte[] body_arr = Encoding.UTF8.GetBytes(body);
            
            byte[] hash;
            lock(hmac_lock) {
                hash = hmac.ComputeHash(body_arr);
            }
            
            string hash_base64 = Convert.ToBase64String(hash); 
            if(hash_base64 != arr[2]) return false;
            
            int iat;
            try { iat =  Convert.ToInt32(arr[1]); }
            catch { return false; }
            
            if(DateTime.Now > ref_date.AddSeconds(iat + token_lifetime)) return false;
            
            try {
                payload = Encoding.UTF8.GetString(Convert.FromBase64String(arr[0]));
            } catch { return false; }
            return true;
        }
        
        private const string src = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        public static string GenerateID(int length) {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] buff = new byte[length];
            rng.GetBytes(buff);
            rng.Dispose();
            
            char[] id = new char[length];
            for(int i = 0; i < length; i++) {
                byte b = (byte)((double)buff[i] * (double)(src.Length-1) / 255.0);
                id[i] = src[b];
            }
            return new string(id);
        }
    }
}