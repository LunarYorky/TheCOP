using TheCoP.Architecture.Interfaces.State_Machines.States;
using TheCoP.Architecture.State_Machines.States;

using UnityEngine;

namespace TheCoP.Scripts__components_.Entities.State_Machines
{
    public class AttackMoveDashStateMachineComponent : AttackMoveStateMachineComponent, IDasher
    {
        // Dasher serialized fields
        [SerializeField] private float dashSpeed = 7f;
        [SerializeField] private int dashStamina = 60;

        // Dasher getters
        public float DashSpeed => dashSpeed;

        protected DashState DashState;

        protected override void Awake()
        {
            base.Awake();
            var statistics = GetComponent<Statistics>();

            DashState = new DashState(this, Animator, Rigidbody2D);

            At(MovementState, DashState, () => WantToDash && statistics.UseUpStamina(dashStamina));
            At(DashState, MovementState, () => !Animator.GetCurrentAnimatorStateInfo(0).IsName("Roll"));

            StateMachine.SetState(MovementState);
        }
    }
}
