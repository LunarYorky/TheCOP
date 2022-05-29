using TheCoP.Architecture.State_Machines;

using UnityEngine;

namespace TheCoP.Scripts__components_.Player_scripts.States
{
    public class PlayerMovementState : IState
    {
        private static readonly int Walk = Animator.StringToHash("Walk");
        private static readonly int Horizontal = Animator.StringToHash("Horizontal");
        private static readonly int Vertical = Animator.StringToHash("Vertical");

        private readonly Player _player;
        private readonly Animator _animator;
        private readonly Rigidbody2D _rigidbody2D;

        public PlayerMovementState(Player player, Animator animator, Rigidbody2D rigidbody2D)
        {
            _player = player;
            _animator = animator;
            _rigidbody2D = rigidbody2D;
        }

        public void Tick()
        {
            var isMoving = _player.Movement.x != 0 || _player.Movement.y != 0;
            _animator.SetBool(Walk, true);
            if (!isMoving) return;

            _animator.SetFloat(Horizontal, _player.Movement.x);
            _animator.SetFloat(Vertical, _player.Movement.y);
            var angle = Vector2.Angle(_player.Movement, Vector2.up);

            if (_player.Movement.x < 0)
                _player.Direction = (360f - angle) * -1f;
            else
                _player.Direction = angle * -1f;
        }

        public void FixTick()
        {
            _rigidbody2D.velocity = _player.Movement * _player.Speed;
        }

        public void OnEnter()
        {
        }

        public void OnExit()
        {
        }
    }
}
