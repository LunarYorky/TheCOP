using UnityEngine;
using UnityEngine.InputSystem;

namespace TheCoP.Architecture.Interfaces.State_Machines
{
    public interface IInputStateMachine
    {
        public void OnFire()
        {
        }

        public void OnDash()
        {
        }

        public void OnMove(InputValue inputValue)
        {
        }

        public void OnMove(Vector2 vector2)
        {
        }
    }
}
