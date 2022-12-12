 using UnityEngine;

 namespace TheCoP.Architecture.Interfaces.State_Machines.States
{
    public interface IMovable
    {
        Vector2 Movement { get; }
        float Speed { get; }
        bool IsMoving { get; }
    }
}
