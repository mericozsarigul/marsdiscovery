using FluentAssertions;
using MarsDiscovery.Constants;
using MarsDiscovery.Models;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace MarsDiscovery.UnitTests
{
    public class MarsDiscoveryTests
    {
        private static IRoverMove _roverMove;

        public MarsDiscoveryTests()
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IMove, Move>()
                .AddTransient<IRoverMove, RoverMove>()
                .BuildServiceProvider();

            _roverMove = serviceProvider.GetService<IRoverMove>();
        }
       
     
        [Theory]
        [InlineData(1,2,5,5, Direction.North, "LMLMLMLMM")]
        public void Rover_ShouldMove_WithScenario1(int xPosition, int yPosition, int xLimit, int yLimit, Direction direction, string order)
        {
            var rover = _roverMove.Move(new Rover(xPosition, yPosition,xLimit,yLimit, direction), order);
            rover.Should().NotBe(null);

            rover.PositionX.Should().Be(1);
            rover.PositionY.Should().Be(3);
            rover.Direction.Should().Be(Direction.North);
        }

        [Theory]
        [InlineData(3, 3, 5, 5, Direction.East, "MRRMMRMRRM")]
        public void Rover_ShouldMove_WithScenario2(int xPosition, int yPosition, int xLimit, int yLimit, Direction direction, string order)
        {
            var rover = _roverMove.Move(new Rover(xPosition, yPosition, xLimit, yLimit, direction), order);
            rover.Should().NotBe(null);
            rover.PositionX.Should().Be(2);
            rover.PositionY.Should().Be(3);
            rover.Direction.Should().Be(Direction.South);
        }
    }
}
