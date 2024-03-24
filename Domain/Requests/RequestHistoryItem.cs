using logistics_management_backend.Domain.Shared;

namespace logistics_management_backend.Domain.Requests
{
    public class RequestHistoryItem{
        public Status status{get;}
        public DateTime startDate;
        //Difference between start and end status in milliseconds
        public long statusDuration;

        public RequestHistoryItem(Status status){
            this.status = status;
            this.startDate = DateTime.UtcNow.Date;
        }

        public void statusChange(){
            DateTime currentDate = DateTime.UtcNow.Date;
            if(currentDate < startDate){
                throw new BusinessRuleValidationException("Current date is before start date, something went wrong");
            }
            if(this.status == Status.RECEIVED){
                throw new BusinessRuleValidationException("Illegal status change!!");
            }
            this.statusDuration = currentDate.Millisecond - startDate.Millisecond;
        }
    }
}