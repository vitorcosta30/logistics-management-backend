using logistics_management_backend.Domain.Requests;

namespace logistics_management_backend.DTO.Requests;

public class RequestHistoryItemDTO
{
    public string status;
    public string startDate;
    public long durantionMs;

    public RequestHistoryItemDTO(Status status, DateTime startDate, long durantionMs)
    {
        this.status = status.ToString();
        this.startDate = this.startDate.ToString();
        this.durantionMs = durantionMs;
    }
}