using logistics_management_backend.Domain.Shared;

namespace logistics_management_backend.Domain.Products;

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
        if (isPositionInvalid(posX,posY))
        {
            throw new BusinessRuleValidationException("Product position is not valid");
        }
        this.posX = posX;
        this.posY = posY;
    }

    private bool isPositionInvalid(int posX, int posY)
    {
        return posX < Warehouse.Warehouse.minX || posX > Warehouse.Warehouse.maxX || posY < Warehouse.Warehouse.minY ||
               posY > Warehouse.Warehouse.maxY;
    }

    public void setPosition(int posX, int posY)
    {
        if (isPositionInvalid(posX,posY))
        {
            throw new BusinessRuleValidationException("Product position is not valid");
        }
        this.posX = posX;
        this.posY = posY;
    }
}