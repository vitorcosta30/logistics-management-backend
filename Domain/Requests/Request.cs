

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

    }
}