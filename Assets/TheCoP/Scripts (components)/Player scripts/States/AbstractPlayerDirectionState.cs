using TheCoP.Architecture.State_Machines;

using UnityEngine;

namespace TheCoP.Scripts__components_.Player_scripts.States
{
    public abstract class AbstractPlayerDirectionState : IState
    {
        private static readonly int Horizontal = Animator.StringToHash("Horizontal");
        private static readonly int Vertical = Animator.StringToHash("Vertical");

        private protected readonly Player Player;
        private readonly Animator _animator;

        protected AbstractPlayerDirectionState(Player player, Animator animator)
        {
            Player = player;
            _animator = animator;
        }

        public virtual void OnEnter()
        {
            CalculateDirection();
        }

        protected void CalculateDirection()
        {
            var isMoving = Player.Movement.x != 0 || Player.Movement.y != 0;
            if (!isMoving) return;

            _animator.SetFloat(Horizontal, Player.Movement.x);
            _animator.SetFloat(Vertical, Player.Movement.y);
            var angle = Vector2.Angle(Player.Movement, Vector2.up);

            if (Player.Movement.x < 0)
                Player.Direction = (360f - angle) * -1f;
            else
                Player.Direction = angle * -1f;
        }
    }
}
