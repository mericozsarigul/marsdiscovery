using MarsDiscovery.Constants;
using MarsDiscovery.Models;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MarsDiscovery
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IMove, Move>()
                .AddTransient<IRoverMove, RoverMove>()
                .BuildServiceProvider();

            var roverMove = serviceProvider.GetService<IRoverMove>();
            var positionX = PositionGetter("Please enter X position:");
            var positionY = PositionGetter("Please enter Y position:");
            var limitX = PositionGetter("Please enter X limit:");
            var limitY = PositionGetter("Please enter Y limit:");
            var direction = DirectionGetter("Please enter direction 0-East 1-North 2-South 3-West:");
 
            var rover = new Rover(positionX, positionY,limitX,limitY, direction);
            Console.WriteLine("Please enter move order:");
            var order = Console.ReadLine();

            rover = roverMove.Move(rover,order);

            Console.WriteLine($"Rover's position is: {rover.PositionX} ,{rover.PositionY}, {rover.Direction}");
        }

        private static int PositionGetter(string message)
        {
            int result;
            bool check = true;
            do
            {
                Console.WriteLine(message);
                var value = Console.ReadLine();
 
                if(!int.TryParse(value,out result))
                    Console.WriteLine($"Your value is not numeric: {value}");

                else
                    check = false;
                
            } while(check);

            return result;
        }

        private static Direction DirectionGetter(string message)
        {
            Direction result;
            bool check = true;
            do
            {
                Console.WriteLine(message);
                var value = Console.ReadLine();

                if (!Enum.TryParse(value, out result))
                    Console.WriteLine($"Your value is not Directional: {value}");

                else
                    check = false;

            } while (check);

            return result;
        }
    }
}
