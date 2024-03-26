using logistics_management_backend.Domain.Shared;

namespace logistics_management_backend.Domain.Goods;

public class ProductPosition : Entity
{
    public int posX { get; set; }
    public int posY { get; set; }

    public ProductPosition()
    {
        this.posX = 0;
        this.posY = 0;
    }
    
    public ProductPosition(int posX, int posY)
    {
        this.posX = posX;
        this.posY = posY;
    }
}