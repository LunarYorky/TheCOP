using TheCoP.Architecture.Interfaces.State_Machines.States;
using TheCoP.Architecture.State_Machines.States;

using UnityEngine;

namespace TheCoP.Scripts__components_.Entities.State_Machines
{
    public class AttackMoveDashStateMachineComponent : AttackMoveStateMachineComponent, IDasher
    {
        // Dasher serialized fields
        [SerializeField] private float dashSpeed = 7f;

        // Dasher getters
        public float DashSpeed => dashSpeed;

        protected DashState DashState;

        protected override void Awake()
        {
            base.Awake();

            DashState = new DashState(this, Animator, Rigidbody2D);

            At(MovementState, DashState, () => WantToDash);
            At(DashState, MovementState, () => !Animator.GetCurrentAnimatorStateInfo(0).IsName("Roll"));

            StateMachine.SetState(MovementState);
        }
    }
}
