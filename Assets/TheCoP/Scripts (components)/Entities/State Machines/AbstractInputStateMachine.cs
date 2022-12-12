using System;

using TheCoP.Architecture.Interfaces.State_Machines;
using TheCoP.Architecture.State_Machines;

using UnityEngine;
using UnityEngine.InputSystem;

namespace TheCoP.Scripts__components_.Entities.State_Machines
{
    public abstract class AbstractInputStateMachine : MonoBehaviour, IInputStateMachine
    {
        // Flags
        protected bool WantToAttack;
        protected bool WantToDash;
        public bool IsMoving { get; private set; }
        public Vector2 Movement { get; private set; } = Vector2.down;

        protected StateMachine StateMachine;
        protected void At(IState from, IState to, Func<bool> condition) => StateMachine.AddTransition(from, to, condition);

        protected virtual void Awake()
        {
            StateMachine = new StateMachine();
        }  

        protected virtual void Update()
        {
            StateMachine.Tick();
            WantToAttack = false;
            WantToDash = false;
        }

        protected virtual void FixedUpdate()
        {
            StateMachine.FixTick();
        }

        public virtual void OnFire()
        {
            WantToAttack = true;
        }

        public virtual void OnDash()
        {
            WantToDash = true;
        }

        public virtual void OnMove(InputValue inputValue)
        {
            var movement = inputValue.Get<Vector2>();
            OnMove(movement);
        }

        public virtual void OnMove(Vector2 movement)
        {
            IsMoving = movement.x != 0 || movement.y != 0;
            if (IsMoving)
            {
                Movement = movement;
            }
        }
    }
}
