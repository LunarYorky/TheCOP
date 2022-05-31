using TheCoP.Architecture.State_Machines;

using UnityEngine;

namespace TheCoP.Scripts__components_.Player_scripts.States
{
    public class PlayerMovementState : AbstractPlayerDirectionState, IState
    {
        private static readonly int Walk = Animator.StringToHash("Walk");

        private readonly Player _player;
        private readonly Animator _animator;
        private readonly Rigidbody2D _rigidbody2D;

        public PlayerMovementState(Player player, Animator animator, Rigidbody2D rigidbody2D) : base(player, animator)
        {
            _player = player;
            _animator = animator;
            _rigidbody2D = rigidbody2D;
        }

        public void Tick()
        {
            var isMoving = _player.Movement.x != 0 || _player.Movement.y != 0;
            _animator.SetBool(Walk, isMoving);
            if (isMoving) CalculateDirection();
        }

        public void FixTick()
        {
            _rigidbody2D.velocity = _player.Movement * _player.Speed;
        }

        public void OnExit()
        {
            _rigidbody2D.velocity = Vector2.zero;
        }
    }
}
