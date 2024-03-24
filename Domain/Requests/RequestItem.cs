using logistics_management_backend.Domain.Goods;
namespace logistics_management_backend.Domain.Requests
{
    public class RequestItem{
        public Product item{get;set;}

        public int quantity{get;set;}

        public RequestItem(){
            this.item = new Product();

        }
        public RequestItem(Product itemId, int quantity){

            this.item = itemId;
            this.quantity = quantity;

        }
    }

}