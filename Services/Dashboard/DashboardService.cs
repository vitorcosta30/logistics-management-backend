using logistics_management_backend.Domain.Shared;
using logistics_management_backend.DTO;
using logistics_management_backend.DTO.Dasboard;
using logistics_management_backend.Infrastructure.Requests;

namespace logistics_management_backend.Services.Dashboard;

public class DashboardService : IDashboardService
{
    
    private readonly IUnitOfWork _unitOfwork;
    private readonly IRequestRepository _repo;

    
    
    public DashboardService(IUnitOfWork unitOfWork, IRequestRepository repository  ){
        this._unitOfwork = unitOfWork;
        this._repo = repository;
    }

    public async Task<DashboardDTO> getDashboardDataAsync(int nDays)
    {
        DateOnly currentDate = DateOnly.FromDateTime(DateTime.UtcNow);
        DashboardDTO dashboardDto = new DashboardDTO();
        dashboardDto.nReqToBeProcessed = await this._repo.getNumberToBeProcessed();
        dashboardDto.nReqOnCollection = await this._repo.getNumberOnCollection();
        dashboardDto.nReqSent = await this._repo.getNumberSent();
        dashboardDto.nReceived = await this._repo.getNumberReceived();
        for (int i = 1; i <= nDays; i++)
        {
            DateOnly date = currentDate.AddDays(-i);
            dashboardDto.toBeProcessedReqData.Add(new DashboardChartPoint(date.Year,date.Month,date.Day,await _repo.requestedOnDate(date)));
            dashboardDto.onCollectionReqData.Add(new DashboardChartPoint(date.Year,date.Month,date.Day,await _repo.onCollectionOnDate(date)));
            dashboardDto.sentReqData.Add(new DashboardChartPoint(date.Year,date.Month,date.Day,await _repo.sentOnDate(date)));
            dashboardDto.receivedReqData.Add(new DashboardChartPoint(date.Year,date.Month,date.Day,await _repo.receivedOnDate(date)));

        }

        return dashboardDto;
    }
}