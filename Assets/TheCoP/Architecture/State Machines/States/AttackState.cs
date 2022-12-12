using TheCoP.Architecture.Interfaces.State_Machines.States;

using UnityEngine;

namespace TheCoP.Architecture.State_Machines.States
{
    public class AttackState : IState
    {
        private static readonly int Attack = Animator.StringToHash("Attack");

        private readonly IAttacker _attacker;
        private readonly Animator _animator;

        public AttackState(IAttacker attacker, Animator animator)
        {
            _attacker = attacker;
            _animator = animator;
        }

        public void OnEnter()
        {
            _animator.Play(Attack);
            var hitBox = Object.Instantiate(
                _attacker.HitBox,
                _attacker.Transform.position,
                Quaternion.Euler(0, 0, _attacker.Direction - _attacker.StartAngle),
                _attacker.Transform
            );
            var hitBoxComponent = hitBox.GetComponent<HitBox>();
            hitBoxComponent.rotationAngle = _attacker.RotationAngle;
            hitBoxComponent.rotationTime = _attacker.RotationTime;
            hitBoxComponent.damage = _attacker.Damage;
        }
    }
}
