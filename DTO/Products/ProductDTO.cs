namespace logistics_management_backend.DTO.Products;

public class ProductDTO
{
    public String description;

    public int xPos;

    public int yPos;

    public long Id;

    public ProductDTO(long Id, String description, int xPos, int yPos)
    {
        this.Id = Id;
        this.description = description;
        this.xPos = xPos;
        this.yPos = yPos;

    }
}