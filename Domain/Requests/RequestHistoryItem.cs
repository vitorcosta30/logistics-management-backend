using logistics_management_backend.Domain.Shared;

namespace logistics_management_backend.Domain.Requests
{
    public class RequestHistoryItem : Entity{
        public Status status{get;}
        public DateTime startDate { get; set; }
        //Difference between start and end status in milliseconds
        public long statusDuration { get; set; }

        public RequestHistoryItem(Status status){
            this.status = status;
            this.startDate = DateTime.UtcNow;
            this.statusDuration = 0;
        }

        public RequestHistoryItem()
        {
            this.startDate = DateTime.UtcNow;
            this.statusDuration = 0;


        }

        public void statusChange(){
            DateTime currentDate = DateTime.UtcNow;
            if(currentDate < startDate){
                throw new BusinessRuleValidationException("Current date is before start date, something went wrong");
            }
            if(this.status == Status.RECEIVED){
                throw new BusinessRuleValidationException("Illegal status change!!");
            }
            this.statusDuration = (long)(currentDate - startDate).TotalMilliseconds;
        }

        public bool isStatusRequested()
        {
            return this.status == Status.REQUESTED;
        }
        public bool isStatusCollection()
        {
            return this.status == Status.COLLECTION;
        }

        public bool isStatusSent()
        {
            return this.status == Status.SENT;
        }
    }
}