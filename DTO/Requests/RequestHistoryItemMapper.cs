using logistics_management_backend.Domain.Requests;

namespace logistics_management_backend.DTO.Requests;

public class RequestHistoryItemMapper
{
    public static RequestHistoryItemDTO toDTO(RequestHistoryItem historyItem)
    {
        return new RequestHistoryItemDTO(historyItem.status, historyItem.startDate, historyItem.statusDuration);
    }

    public static RequestHistoryItemDTO[] toDTO(RequestHistory history)
    {
        return history.previousStatus.ConvertAll<RequestHistoryItemDTO>(reqHIst => toDTO(reqHIst)).ToArray();
    }

}