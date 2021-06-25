using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FastAuth;
using mainServer.Models;
using Microsoft.AspNetCore.Mvc;
using Server;
using Server2;

namespace mainServer.Controllers.Dashboard.UserDashboard
{

    public class SalesModel
    {
        public string product_id{get; set;}
        public string product_name{get; set;}
        public int quantity {get; set;}
        public string category {get; set;}
    }


    public class SalesController : BaseController
    {
        public async  Task<ActionResult<List<ProductModel>>> GetSalesList(string pool,int offset_sales,int perPageCount_sales)
        {

            string user_shop_id = GetUserID();

            if(pool == "NotDefault"){
                var res_refresh = await DAL.ExecuteReaderAsync<ProductModel>(
                    @"SELECT product_id,product_name,category,
                    quantity,upload_date,number_of_orders,
                    status,user_shop_id
                    FROM product_list WHERE user_shop_id = @user_shop_id
                    LIMIT "+offset_sales+", "+perPageCount_sales+@" 
                    ",
                    new string[,]{
                        {"@user_shop_id", user_shop_id}

                    }
                );

                return res_refresh;

            }


            var res = await DAL.ExecuteReaderAsync<ProductModel>(
                @"SELECT product_id,product_name,category,
                    quantity,upload_date,number_of_orders,
                    status,user_shop_id
                    FROM product_list WHERE user_shop_id = @user_shop_id
                    LIMIT "+offset_sales+", "+perPageCount_sales+@" 
                    ",
                    new string[,]{
                        {"@user_shop_id", user_shop_id}

                    }
            );

            if(res.Count == 0){
                List<ProductModel> newList = new List<ProductModel>();
                ProductModel newProductModel = new ProductModel();
                newProductModel.product_id = "00";
                newList.Add(newProductModel);
                return newList;
            }

            return res;
        }

        public async Task<IActionResult> AddNewItem(string product_name, string category, string quantity)
        {


            string user_id = GetUserID();
            int quantity_int = Convert.ToInt32(quantity);

            Console.WriteLine(quantity_int.GetType() + "   : "+ quantity_int);


            var item_data = await DAL.ExecuteNonQueryAsync(
                @"INSERT INTO product_list (
                    product_id,
                    product_name,
                    category,
                    quantity,
                    upload_date,
                    number_of_orders,
                    status,
                    user_shop_id
                )
                VALUES ( 
                    @product_id, 
                    @product_name,
                    @category,
                    "+quantity_int+@",
                    @upload_date,
                    "+ 0 +@",
                    @status,
                    @user_shop_id)",
                new string[,]{
                    {"@product_id", FAuth.GenerateID(12)},
                    {"@product_name", product_name},
                    {"@category", category },
                    {"@upload_date", MySqlUtility.ConvertTo_MySqlDate(DateTime.Now)},
                    {"@status", "pending"},
                    {"@user_shop_id",user_id}
                }
            );

            return Ok(200);
        }
    }
}