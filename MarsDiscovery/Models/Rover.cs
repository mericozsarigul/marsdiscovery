using MarsDiscovery.Constants;

namespace MarsDiscovery.Models
{
    public class Rover
    {
        public Rover(int positionX, int positionY, int limitX, int limitY, Direction direction)
        {
            PositionX = positionX;
            PositionY = positionY;
            LimitX = limitX;
            LimitY = limitY;
            Direction = direction;
        }

        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public int LimitX { get; set; }
        public int LimitY { get; set; }
        public Direction Direction { get; set; }

    }
}
