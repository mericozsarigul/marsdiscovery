using MarsDiscovery.Constants;
using System;

namespace MarsDiscovery.Models
{
    public class Move : IMove
    {
        public Rover TurnLeft(Rover rover)
        {
            if(rover == null)
                throw new ArgumentException("Rover can not be null.");

            switch (rover.Direction)
            {
                case Direction.East:
                    rover.Direction = Direction.North;
                    break;
                case Direction.North:
                    rover.Direction = Direction.West;
                    break;
                case Direction.West:
                    rover.Direction = Direction.South;
                    break;
                case Direction.South:
                    rover.Direction = Direction.East;
                    break;
                default:
                    throw new ArgumentException($"Direction:{rover.Direction} is not defined.");
            }

            return rover;
        }

        public Rover TurnRight(Rover rover)
        {
            if (rover == null)
                throw new ArgumentException("Rover can not be null.");

            switch (rover.Direction)
            {
                case Direction.East:
                    rover.Direction = Direction.South;
                    break;
                case Direction.North:
                    rover.Direction = Direction.East;
                    break;
                case Direction.West:
                    rover.Direction = Direction.North;
                    break;
                case Direction.South:
                    rover.Direction = Direction.West;
                    break;
                default:
                    throw new ArgumentException($"Direction:{rover.Direction} is not defined.");
            }

            return rover;
        }

        public Rover ForwardStep(Rover rover)
        {
            if (rover == null)
                throw new ArgumentException("Rover can not be null.");

            switch (rover.Direction)
            {
                case Direction.East:
                    rover.PositionX++;
                    break;
                case Direction.North:
                    rover.PositionY++;
                    break;
                case Direction.West:
                    rover.PositionX--;
                    break;
                case Direction.South:
                    rover.PositionY--;
                    break;
                default:
                    throw new ArgumentException($"Direction:{rover.Direction} is not defined.");
            }

            return rover;
        }
    }
}
