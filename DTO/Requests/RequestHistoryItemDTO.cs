using logistics_management_backend.Domain.Requests;

namespace logistics_management_backend.DTO.Requests;

public class RequestHistoryItemDTO
{
    public string status;
    public string startDate;
    public long durationMs;

    public RequestHistoryItemDTO(Status status, DateTime startDate, long durationMs)
    {
        this.status = status.ToString();
        this.startDate = startDate.ToString();
        this.durationMs = durationMs;
    }
}