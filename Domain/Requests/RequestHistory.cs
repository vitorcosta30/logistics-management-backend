using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using logistics_management_backend.Domain.Shared;

namespace logistics_management_backend.Domain.Requests
{
    public class RequestHistory : Entity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id;
        public RequestHistoryItem currentStatus;

        public List<RequestHistoryItem> previousStatus;
        
        public RequestHistory(){
            this.currentStatus = new RequestHistoryItem(Status.REQUESTED);
            this.previousStatus = new List<RequestHistoryItem>();
        }

        public void startCollection(){
            if(this.currentStatus.status == Status.REQUESTED){
                statusChange(Status.COLLECTION);
            }else{
                throw new BusinessRuleValidationException("Illegal Status change!!");
            }
        }

        public bool isToBeProcessed()
        {
            return this.currentStatus.isStatusRequested();
        }
        private void statusChange(Status newState){
                this.currentStatus.statusChange();
                this.previousStatus.Add(currentStatus);
                this.currentStatus = new RequestHistoryItem(newState);

        }

    }
}