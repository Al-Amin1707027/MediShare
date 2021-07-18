using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using FastAuth;
using Server;
using Server2;
using System.Threading.Tasks;
using System.Collections.Specialized;
using Microsoft.AspNetCore.Http;
using mainServer.Models;

namespace mainServer.Controllers.Dashboard.UserDashboard
{


    public class OrderModel
    {
        public string product_id{get; set;}
        public string product_name{get; set;}
        public int quantity {get; set;}
        public string status {get; set;}
        public string order_date {get; set;}
    }
    public class OrderController : BaseController
    {

        public async Task<ActionResult<List<OrderModel>>> GetOrderList(string pool,int offset_sales,int perPageCount_sales)
        {

            string user_id = GetUserID();
            if(user_id == null){
                return Redirect("/Login");
            }
            var order_list = await DAL.ExecuteReaderAsync<OrderModel>(
                @"SELECT product_id,product_name,quantity,status,order_date 
                FROM orders WHERE user_id=@user_id",
                new string[,]{
                    {"@user_id", user_id}
                }
            );

            return order_list;
        }
        
    }
}