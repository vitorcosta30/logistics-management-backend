namespace logistics_management_backend.DTO.Dasboard;

public class DashboardDTO
{
    public int nReqToBeProcessed { get; set; }

    public int nReqOnCollection { get; set; }

    public int nReqSent { get; set; }

    public int nReceived { get; set; }

    public List<DashboardChartPoint> toBeProcessedReqData;
    public List<DashboardChartPoint> onCollectionReqData;
    public List<DashboardChartPoint> sentReqData;
    public List<DashboardChartPoint> receivedReqData;
    public DashboardDTO(List<DashboardChartPoint> toBeProcessedReqData, List<DashboardChartPoint> onCollectionReqData,List<DashboardChartPoint> sentReqData, List<DashboardChartPoint> receivedReqData, int nReqToBeProcessed, int nReqOnCollection, int nReqSent, int nReceived)
    {
        this.toBeProcessedReqData = toBeProcessedReqData;
        this.onCollectionReqData = onCollectionReqData;
        this.sentReqData = sentReqData;
        this.receivedReqData = receivedReqData;
        this.nReqToBeProcessed = nReqToBeProcessed;
        this.nReqOnCollection = nReqOnCollection;
        this.nReqSent = nReqSent;
        this.nReceived = nReceived;
    }

    public DashboardDTO()
    {
        this.nReqToBeProcessed = 0;
        this.nReqOnCollection = 0;
        this.nReqSent = 0;
        this.nReceived = 0;
        this.toBeProcessedReqData = new List<DashboardChartPoint>();
        this.onCollectionReqData =  new List<DashboardChartPoint>();
        this.sentReqData =  new List<DashboardChartPoint>();
        this.receivedReqData =  new List<DashboardChartPoint>();
    }



}