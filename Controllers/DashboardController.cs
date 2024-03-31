using logistics_management_backend.DTO.Dasboard;
using logistics_management_backend.Services.Dashboard;
using Microsoft.AspNetCore.Mvc;

namespace logistics_management_backend.Controllers;
[Route("api/[controller]")]
[ApiController]
public class DashboardController : ControllerBase
{
    
    private readonly IDashboardService _service;
    private int[] dasnboardOptions = {7, 14, 30, 60, 90};

    public DashboardController( IDashboardService service)
    {
        _service = service;
    }
    [HttpGet("{option}")]
    public async Task<ActionResult<DashboardDTO>> GetDashboard(int option)
    {
        switch (option)
        {
            case 0:
                return await this._service.getDashboardDataAsync(dasnboardOptions[0]);
            
            case 1:
                return await this._service.getDashboardDataAsync(dasnboardOptions[1]);
            
            case 2:
                return await this._service.getDashboardDataAsync(dasnboardOptions[2]);
            
            case 3:
                return await this._service.getDashboardDataAsync(dasnboardOptions[3]); 
            case 4:
                return await this._service.getDashboardDataAsync(dasnboardOptions[4]); 
        }

        return BadRequest("Illegal dashboard option!!");

    }
}