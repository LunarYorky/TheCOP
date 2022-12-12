using TheCoP.Architecture.Interfaces.State_Machines.States;
using TheCoP.Architecture.State_Machines.States;

using UnityEngine;

namespace TheCoP.Scripts__components_.Entities.State_Machines
{
    public class AttackMoveStateMachineComponent : AbstractInputStateMachine, IMovable, IAttacker
    {
        // Movable fields
        // Movable serialized fields
        [SerializeField] private float speed = 4f;
        // Attacker serialized fields
        [SerializeField] private int startAngle = -85;
        [SerializeField] private float rotationAngle = 150f;
        [SerializeField] private float rotationTime = 0.2f;
        [SerializeField] private float damage = 10f;
        [SerializeField] private GameObject hitBox;

        // Movable getters
        public float Speed => speed;
        // Attacker getters
        public int StartAngle => startAngle;
        public float RotationAngle => rotationAngle;
        public float RotationTime => rotationTime;
        public float Damage => damage;
        public float Direction
        {
            get
            {
                float direction;
                var angle = Vector2.Angle(Movement, Vector2.up);
                if (Movement.x < 0)
                {
                    direction = (360f - angle) * -1f;
                }
                else
                    direction = angle * -1f;

                return direction;
            }
        }
        public Transform Transform => transform;
        public GameObject HitBox => hitBox;

        protected Animator Animator;
        protected Rigidbody2D Rigidbody2D;
        protected MovementState MovementState;
        protected AttackState AttackState;
        
        protected override void Awake()
        {
            base.Awake();
            Animator = GetComponentInChildren<Animator>(); // TODO: should be one Animator for one entity
            Rigidbody2D = GetComponent<Rigidbody2D>();

            MovementState = new MovementState(this, Animator, Rigidbody2D);
            AttackState = new AttackState(this, Animator);

            At(MovementState, AttackState, () => WantToAttack);
            At(AttackState, MovementState, () => !Animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"));

            StateMachine.SetState(MovementState);
        }
    }
}
