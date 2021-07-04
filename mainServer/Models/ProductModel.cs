namespace mainServer.Models
{
    public class ProductModel
    {
        public string product_id {get;set;}
        public string product_name {get;set;}
        public string category {get;set;}
        public int quantity {get;set;}
        public string upload_date {get;set;}
        public int number_of_orders {get;set;}
        public string status {get;set;}
        public string user_shop_id {get;set;}
        public int per_unit_price {get; set;}
        public string file_name {get; set;}
    }
}