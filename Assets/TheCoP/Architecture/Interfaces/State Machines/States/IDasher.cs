namespace TheCoP.Architecture.Interfaces.State_Machines.States
{
    public interface IDasher : IMovable
    {
        float DashSpeed { get; }
    }
}
