using logistics_management_backend.Domain.Goods;
using logistics_management_backend.Domain.Products;
using logistics_management_backend.Domain.Shared;

namespace logistics_management_backend.Domain.Requests
{
    public class RequestItemList : Entity
    {
        public List<RequestItem> items;

        public RequestItemList (){
            this.items = new List<RequestItem>();

        }

        public RequestItemList(List<RequestItem> items){
            this.items = items;
        }

        public void addItem(RequestItem item){
            this.items.Add(item);
        }

        public void collectedItems(long idItem)
        {
            this.items.Find(item => item.Id == idItem)?.wasCollected();
        }

        public bool areAllItemsCollected()
        { 
            return this.items.TrueForAll(item => item.collected) ;
        }

        public ProductPosition[] shortestRoute()
        {
            //copy.Sort((item1, item2) => item1.item.position.posX - item2.item.position.posX);
            List<ProductPosition> points = new List<ProductPosition>();
            this.items.ForEach(item => points.Add(item.item.position));
            ProductPosition currentPoint = new ProductPosition(0, 0);
            List<ProductPosition> route = new List<ProductPosition>();
            route.Add(currentPoint);
            while (points.Count > 0)
            {
                ProductPosition nextPosition = nextPoint( points, currentPoint);
                points.Remove(nextPosition);
                route.Add(nextPosition);
                currentPoint = nextPosition;
            }

            return route.ToArray();

        }

        private ProductPosition nextPoint(List<ProductPosition> remainingPositions, ProductPosition currentPoint)
        {
            ProductPosition pos = remainingPositions[0];
            double distance = distanceBetweenTwoPoints(currentPoint, pos);
            for (int i = 1; i < remainingPositions.Count; i++)
            {
                double newDistance = distanceBetweenTwoPoints(remainingPositions[i], currentPoint);
                if (newDistance < distance)
                {
                    pos = remainingPositions[i];
                    distance = newDistance;
                }

            }

            return pos;
        }

        private double distanceBetweenTwoPoints(ProductPosition pos1, ProductPosition pos2)
        {
            return Math.Sqrt(((pos1.posX - pos2.posX) * (pos1.posX - pos2.posX)) +
                   ((pos1.posY - pos2.posY) * (pos1.posY - pos2.posY)));
        }
        
    }
}
