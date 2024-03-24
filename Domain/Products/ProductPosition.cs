namespace logistics_management_backend.Domain.Goods;

public class ProductPosition
{
    public int posX { get; set; }
    public int posY { get; set; }

    public ProductPosition()
    {
        this.posX = 0;
        this.posY = 0;
    }
}