

using logistics_management_backend.Domain.Goods;
using logistics_management_backend.Domain.Shared;

namespace logistics_management_backend.Domain.Requests
{
    public class Request : Entity {

        public RequestItemList listOfItems;
        public RequestHistory status;
        public Request(){
            listOfItems = new RequestItemList();
            status = new RequestHistory();

        }
        public Request(RequestItemList itemList ){
            this.listOfItems = itemList;
            this.status = new RequestHistory();
        }

        public void addItem(RequestItem newItem)
        {
            listOfItems.addItem(newItem);
        }

        public void itemWasCollected(Product product)
        {
            this.listOfItems.collectedItems(product);
        }

        public void startCollection()
        {
            if(this.status.isToBeProcessed()){
                this.status.startCollection();
            }else{
                throw new BusinessRuleValidationException("Illegal Status change!!");
            }
        }

        public void sendRequest()
        {
            if (this.status.isOnCollection() && this.listOfItems.areAllItemsCollected())
            {
                this.status.sendRequest();
            }
            else
            {
                throw new BusinessRuleValidationException("Illegal Status change!! All goods haven't been collected or request is no longer on collection!!");
            }
        }

    }
}