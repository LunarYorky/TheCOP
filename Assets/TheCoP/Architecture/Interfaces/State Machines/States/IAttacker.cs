using UnityEngine;

namespace TheCoP.Architecture.Interfaces.State_Machines.States
{
    public interface IAttacker
    {
        int StartAngle { get; }
        float RotationAngle { get; }
        float RotationTime { get; }
        float Damage { get; }
        float Direction { get; }
        Transform Transform { get; }
        GameObject HitBox { get; }
    }
}
