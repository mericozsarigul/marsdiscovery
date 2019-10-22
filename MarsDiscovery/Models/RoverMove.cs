using System;

namespace MarsDiscovery.Models
{
    public class RoverMove : IRoverMove
    {
        private static IMove _move;
        public RoverMove(IMove move)
        {
            _move = move;
        }
        public Rover Move(Rover rover, string moves)
        {
            if(rover == null)
                throw new ArgumentException("Rover can not be null.");

            if(string.IsNullOrEmpty(moves))
                throw new ArgumentException("Orders can not be null.");

            foreach (var move in moves)
            {
                switch (move)
                {
                    case 'M':
                        rover = _move.ForwardStep(rover);
                        break;
                    case 'L':
                        rover = _move.TurnLeft(rover);
                        break;
                    case 'R':
                        rover = _move.TurnRight(rover);
                        break;
                    default:
                        throw new ArgumentException($"Invalid navigate character: {move}");
                }
                
                if(rover.PositionX < 0)
                    throw new Exception($"The position of the rover: {rover.PositionX} has reached X minimum limit: 0");

                if (rover.PositionY < 0)
                    throw new Exception($"The position of the rover: {rover.PositionY} has reached Y minimum limit: 0");

                if (rover.PositionX > rover.LimitX)
                    throw new Exception($"The position of the rover: {rover.PositionX} has reached X maximum limit: {rover.LimitX}");

                if (rover.PositionX > rover.LimitY)
                    throw new Exception($"The position of the rover: {rover.PositionY} has reached X maximum limit: {rover.LimitY}");
            }

            return rover;
        }
    }
}
