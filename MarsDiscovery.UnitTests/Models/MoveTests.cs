using MarsDiscovery.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xunit;

namespace MarsDiscovery.UnitTests.Models
{
    public class MoveTests
    {
        private static IMove _move;

        public MoveTests()
        {
            var serviceProvider = new ServiceCollection()
                .AddTransient<IMove, Move>()
                .BuildServiceProvider();

            _move = serviceProvider.GetService<IMove>();
        }

        [Fact]
        public void NullCase_ShouldNotWork()
        {
            Assert.Throws<ArgumentException>(() => _move.ForwardStep(null));
            Assert.Throws<ArgumentException>(() => _move.TurnRight(null));
            Assert.Throws<ArgumentException>(() => _move.TurnLeft(null));
        }
    }
}
