using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace mainServer.Controllers.Dashboard.UserDashboard
{


    public class OrderModel
    {
        public string product_id{get; set;}
        public string product_name{get; set;}
        public int quantity {get; set;}
        public string category {get; set;}
    }
    public class OrderController : Controller
    {

        public ActionResult<List<OrderModel>> GetOrderList(string pool,int offset_sales,int perPageCount_sales)
        {

            Console.WriteLine(pool+" + " + offset_sales);

            OrderModel OrderModel = new OrderModel();
            OrderModel.product_id = "HSTEDYCKD";
            OrderModel.product_name = "Napa Extra";
            OrderModel.quantity = 9;
            OrderModel.category = "other";

            List<OrderModel> sales_list = new List<OrderModel>();
            sales_list.Add(OrderModel);

            return sales_list;
        }
        
    }
}