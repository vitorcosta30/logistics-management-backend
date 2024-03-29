using logistics_management_backend.Domain.Goods;
using logistics_management_backend.Domain.Shared;

namespace logistics_management_backend.Domain.Requests
{
    public class RequestItem : Entity{
        public Product item{get;set;}

        public int quantity{get;set;}
        
        public bool collected { get; set; }

        public RequestItem(){
            this.item = new Product();
            this.quantity = 0;
            this.collected = false;

        }
        public RequestItem(Product itemId, int quantity){

            this.item = itemId;
            this.quantity = quantity;
            this.collected = false;

        }

        public void wasCollected()
        {
            this.collected = true;
        }
    }

}