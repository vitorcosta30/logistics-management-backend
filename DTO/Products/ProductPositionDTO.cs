namespace logistics_management_backend.DTO.Products;

public class ProductPositionDTO
{
    public int posX { get; set; }
    public int posY { get; set; }


    public ProductPositionDTO(int posX, int posY)
    {
        this.posX = posX;
        this.posY = posY;
    }
}