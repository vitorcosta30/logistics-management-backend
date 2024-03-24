using logistics_management_backend.Domain.Shared;

namespace logistics_management_backend.Domain.Goods
{
    public class Product : Entity{


        public String description{get; set;}
        public Product(){
        this.description = "";
        }
        public Product(String idGoods, String description ){
            this.description = description;

        }
        
    }
}