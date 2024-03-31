using logistics_management_backend.DTO.Dasboard;

namespace logistics_management_backend.Services.Dashboard;

public interface IDashboardService
{
    Task<DashboardDTO> getDashboardDataAsync(int nDays);

}