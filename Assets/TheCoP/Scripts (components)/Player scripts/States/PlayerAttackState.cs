using TheCoP.Architecture.State_Machines;

using UnityEngine;

namespace TheCoP.Scripts__components_.Player_scripts.States
{
    public class PlayerAttackState : IState
    {
        private readonly Player _player;
        private const int StartAngle = -85;
        private const float RotationAngle = 150f;
        private const float RotationTime = 0.2f;
        private const float Damage = 10;

        public PlayerAttackState(Player player)
        {
            _player = player;
        }

        public void Tick()
        {
        }

        public void FixTick()
        {
        }

        public void OnEnter()
        {
            _player.PlayAnimator("Attack");
            var hitBox = Object.Instantiate(
                _player.Box,
                _player.transform.position,
                Quaternion.Euler(0, 0, _player.Direction - StartAngle),
                _player.transform
            );
            var hitBoxComponent = hitBox.GetComponent<HitBox>();
            hitBoxComponent.rotationAngle = RotationAngle;
            hitBoxComponent.rotationTime = RotationTime;
            hitBoxComponent.damage = Damage;
        }

        public void OnExit()
        {
        }
    }
}
