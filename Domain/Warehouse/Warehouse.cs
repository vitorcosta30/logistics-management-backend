namespace logistics_management_backend.Domain.Warehouse;

//Class that store information about warehouse and helps with mapping
//Currently is not persisted in the database as, for now, it is not asked
//Some of the information stored in this class can be the dimensions of the warehouse, obstacles positions
//such as aisles columns and shelves
//This information can then be used to validate products positions and calculate routes
public class Warehouse
{
    //only warehouse limits are being stores as of this moment to validate product positions
    public static int minX = 0;
    public static int minY = 0;
    
    public static int maxX = 500;
    public static int maxY = 500;

}