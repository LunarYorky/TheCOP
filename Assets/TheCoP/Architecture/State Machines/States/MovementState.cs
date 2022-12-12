using TheCoP.Architecture.Interfaces.State_Machines.States;

using UnityEngine;

namespace TheCoP.Architecture.State_Machines.States
{
    public class MovementState : IState
    {
        private static readonly int Horizontal = Animator.StringToHash("Horizontal");
        private static readonly int Vertical = Animator.StringToHash("Vertical");
        private static readonly int IsMoving = Animator.StringToHash("IsMoving");

        private readonly IMovable _movable;
        private readonly Animator _animator;
        private readonly Rigidbody2D _rigidbody2D;

        public MovementState(IMovable movable, Animator animator, Rigidbody2D rigidbody2D)
        {
            _movable = movable;
            _animator = animator;
            _rigidbody2D = rigidbody2D;
        }

        public void Tick()
        {
            CalculateDirection();
        }

        public void FixTick()
        {
            _rigidbody2D.velocity = _movable.IsMoving ? _movable.Movement * _movable.Speed : Vector2.zero;
        }

        public void OnEnter()
        {
            CalculateDirection();
        }

        public void OnExit()
        {
            CalculateDirection();
            _rigidbody2D.velocity = Vector2.zero;
        }

        private void CalculateDirection()
        {
            var isMoving = _movable.IsMoving;
            _animator.SetBool(IsMoving, isMoving);
            if (!isMoving) return;
            _animator.SetFloat(Horizontal, _movable.Movement.x);
            _animator.SetFloat(Vertical, _movable.Movement.y);
        }
    }
}
