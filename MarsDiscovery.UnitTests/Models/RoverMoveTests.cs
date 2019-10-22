using MarsDiscovery.Constants;
using MarsDiscovery.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xunit;

namespace MarsDiscovery.UnitTests.Models
{
    public class RoverMoveTests
    {
        private static IRoverMove _roverMove;

        public RoverMoveTests()
        {
            var serviceProvider = new ServiceCollection()
                .AddTransient<IMove, Move>()
                .AddTransient<IRoverMove, RoverMove>()
                .BuildServiceProvider();

            _roverMove = serviceProvider.GetService<IRoverMove>();
        }

        [Fact]
        public void NullCase_ShouldNotWork()
        {
            Assert.Throws<ArgumentException>(() => _roverMove.Move(null,null));
            Assert.Throws<ArgumentException>(() => _roverMove.Move(null, "adasd"));
            Assert.Throws<ArgumentException>(() => _roverMove.Move(null, ""));
            Assert.Throws<ArgumentException>(() => _roverMove.Move(new Rover(1,1,1,1,Direction.East), null));
        }

        [Theory]
        [InlineData(0, 0, 1, 1, Direction.West, "MMMMMMM")]
        public void Rover_ShouldNotMove_WithLimit(int xPosition, int yPosition, int xLimit, int yLimit, Direction direction, string order)
        {
            Assert.Throws<Exception>(() => _roverMove.Move(new Rover(xPosition, yPosition, xLimit, yLimit, direction), order));
        }

        [Theory]
        [InlineData(0, 0, 1, 1, Direction.West, "ADSADSASD")]
        public void Rover_ShouldNotMove_WithWrongOrder(int xPosition, int yPosition, int xLimit, int yLimit, Direction direction, string order)
        {
            Assert.Throws<ArgumentException>(() => _roverMove.Move(new Rover(xPosition, yPosition, xLimit, yLimit, direction), order));
        }
    }
}
