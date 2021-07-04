using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FastAuth;
using mainServer.Models;
using Microsoft.AspNetCore.Mvc;
using Server;
using Server2;
using Microsoft.AspNetCore.Http;
using System.IO;

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

            //keep in mind user_shop_id = user_id

            string user_shop_id = GetUserID();

            if(pool == "NotDefault"){
                var res_refresh = await DAL.ExecuteReaderAsync<ProductModel>(
                    @"SELECT product_id,product_name,category,
                    quantity,upload_date,number_of_orders,
                    status,user_shop_id,per_unit_price
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
                    status,user_shop_id,per_unit_price,file_name
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



        public async Task<IActionResult> UploadFile(string product_name, string category, int quantity,int per_unit_price,string remark,IFormFile file)
        {
            
            
            Console.WriteLine(product_name);
            Console.WriteLine(category);
            Console.WriteLine(quantity);
            Console.WriteLine(per_unit_price);
            
            bool isSaveSuccess = false;
            string fileName = "";

            try{
                var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
                fileName = DateTime.Now.Ticks + extension;
                Console.WriteLine(fileName);

                var pathBuilt = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\ProductImages");

                if(!Directory.Exists(pathBuilt)){
                    Directory.CreateDirectory(pathBuilt);
                }

                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\ProductImages",fileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                
                Console.WriteLine("file is uploading.......");
                
                isSaveSuccess = true;
            }
            catch (Exception e)
            {
                // Console.Writeline(e);
            }



            string user_id = GetUserID();


            var item_data = await DAL.ExecuteNonQueryAsync(
                @"INSERT INTO product_list (
                    product_id,
                    product_name,
                    category,
                    quantity,
                    upload_date,
                    number_of_orders,
                    status,
                    user_shop_id,
                    per_unit_price,
                    remark,
                    file_name
                )
                VALUES ( 
                    @product_id, 
                    @product_name,
                    @category,
                    "+quantity+@",
                    @upload_date,
                    "+ 0 +@",
                    @status,
                    @user_shop_id,
                    "+per_unit_price+@",
                    @remark,
                    @file_name)",
                new string[,]{
                    {"@product_id", FAuth.GenerateID(12)},
                    {"@product_name", product_name},
                    {"@category", category },
                    {"@upload_date", MySqlUtility.ConvertTo_MySqlDate(DateTime.Now)},
                    {"@status", "pending"},
                    {"@user_shop_id",user_id},
                    {"@remark",remark},
                    {"@file_name", fileName}
                }
            );

            return Redirect("~/userdashboard");
        }
    }
}