using logistics_management_backend.Domain.Goods;
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

        public void collectedItems(long idItem)
        {
            this.items.Find(item => item.Id == idItem)?.wasCollected();
        }

        public bool areAllItemsCollected()
        { 
            return this.items.TrueForAll(item => item.collected) ;
        }
        
        
    }
}
