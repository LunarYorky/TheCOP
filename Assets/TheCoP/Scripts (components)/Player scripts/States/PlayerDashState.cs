using UnityEngine;

namespace TheCoP.Scripts__components_.Player_scripts.States
{
    public class PlayerDashState : AbstractPlayerDirectionState
    {
        private readonly Rigidbody2D _rigidbody2D;

        public PlayerDashState(Player player, Animator animator, Rigidbody2D rigidbody2D) : base(player, animator)
        {
            _rigidbody2D = rigidbody2D;
        }

        public override void OnEnter()
        {
            base.OnEnter();

            Player.PlayAnimator("Roll");
            _rigidbody2D.AddForce(Player.Movement.normalized * Player.DashSpeed, ForceMode2D.Impulse);
        }
    }
}
