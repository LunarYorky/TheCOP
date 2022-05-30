using UnityEngine;

namespace TheCoP.Scripts__components_.Player_scripts.States
{
    public class PlayerAttackState : AbstractPlayerDirectionState
    {
        private const int StartAngle = -85;
        private const float RotationAngle = 150f;
        private const float RotationTime = 0.2f;
        private const float Damage = 10;

        public PlayerAttackState(Player player, Animator animator) : base(player, animator)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();

            Player.PlayAnimator("Attack");
            var hitBox = Object.Instantiate(
                Player.Box,
                Player.transform.position,
                Quaternion.Euler(0, 0, Player.Direction - StartAngle),
                Player.transform
            );
            var hitBoxComponent = hitBox.GetComponent<HitBox>();
            hitBoxComponent.rotationAngle = RotationAngle;
            hitBoxComponent.rotationTime = RotationTime;
            hitBoxComponent.damage = Damage;
        }
    }
}
