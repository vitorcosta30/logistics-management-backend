namespace logistics_management_backend.DTO;

public class DashboardChartPoint
{
    public int year;

    public int month;
    public int day;

    public int quantity;

    public DashboardChartPoint(int year, int month, int day, int quantity)
    {
        this.year = year;
        this.day = day;
        this.month = month;
        this.quantity = quantity;
    }
    
}