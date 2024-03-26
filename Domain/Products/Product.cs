using logistics_management_backend.Domain.Shared;

namespace logistics_management_backend.Domain.Goods
{
    public class Product : Entity{


        public String description{get; set;}
        public ProductPosition position { get; set; }
        public Product(){
        this.description = "";
        }
        public Product(String description ){
            this.description = description;
            this.position = new ProductPosition();

        }
        public Product(String description, ProductPosition position ){
            this.description = description;
            this.position = position;

        }
        public Product(String description, int xPos, int yPos ){
            this.description = description;
            this.position = new ProductPosition(xPos,yPos);

        }
        
        
    }
}