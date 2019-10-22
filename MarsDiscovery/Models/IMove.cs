namespace MarsDiscovery.Models
{
    public interface IMove
    {
        Rover TurnLeft(Rover rover);
        Rover TurnRight(Rover rover);
        Rover ForwardStep(Rover rover);
    }
}
