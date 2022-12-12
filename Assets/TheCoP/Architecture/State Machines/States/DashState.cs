using TheCoP.Architecture.Interfaces.State_Machines.States;

using UnityEngine;

namespace TheCoP.Architecture.State_Machines.States
{
    public class DashState : IState
    {
        private static readonly int Roll = Animator.StringToHash("Roll");

        private readonly IDasher _dasher;
        private readonly Animator _animator;
        private readonly Rigidbody2D _rigidbody2D;

        public DashState(IDasher dasher, Animator animator, Rigidbody2D rigidbody2D)
        {
            _dasher = dasher;
            _animator = animator;
            _rigidbody2D = rigidbody2D;
        }

        public void OnEnter()
        {
            _animator.Play(Roll);
            _rigidbody2D.AddForce(_dasher.Movement * _dasher.DashSpeed, ForceMode2D.Impulse);
        }
    }
}
