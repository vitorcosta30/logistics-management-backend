using logistics_management_backend.Domain.Shared;

namespace logistics_management_backend.Domain.Requests
{
    public class RequestItemList : Entity
    {
        public List<RequestItem> items;

        public RequestItemList (){
            this.items = new List<RequestItem>();

        }

        public RequestItemList(List<RequestItem> items){
            this.items = items;
        }

        public void addItem(RequestItem item){
            this.items.Add(item);
        }
        
        
    }
}
