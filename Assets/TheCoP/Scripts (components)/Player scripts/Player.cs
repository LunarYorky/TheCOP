using System;

using TheCoP.Architecture.State_Machines;
using TheCoP.Scripts__components_.Player_scripts.States;

using UnityEngine;
using UnityEngine.InputSystem;

namespace TheCoP.Scripts__components_.Player_scripts
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private GameObject _box;
        public GameObject Box => _box;
        [SerializeField] private float _speed;
        public float Speed
        {
            get => _speed;
            set => _speed = value;
        }
        [SerializeField] private float _dashSpeed;
        public float DashSpeed
        {
            get => _dashSpeed;
            set => _dashSpeed = value;
        }
        public Vector2 Movement { get; private set; }
        public float Direction { get; set; }
        private StateMachine _stateMachine;
        private Animator _animator;
        private bool _wantToAttack;
        private bool _wantToDash;

        private void Awake()
        {
            _animator = GetComponentInChildren<Animator>();

            _stateMachine = new StateMachine();

            var rigidbody2d = GetComponent<Rigidbody2D>();

            var movement = new PlayerMovementState(this, _animator, rigidbody2d);
            var attack = new PlayerAttackState(this, _animator);
            var dash = new PlayerDashState(this, _animator, rigidbody2d);

            At(movement, dash, () => _wantToDash && (Movement.x != 0 || Movement.y != 0));
            At(movement, attack, () => _wantToAttack);
            At(attack, movement, () => !_animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"));
            At(dash, movement, () => !_animator.GetCurrentAnimatorStateInfo(0).IsName("Roll"));

            _stateMachine.SetState(movement);

            void At(IState to, IState from, Func<bool> condition) => _stateMachine.AddTransition(to, from, condition);
        }

        private void Update()
        {
            _stateMachine.Tick();
            _wantToAttack = false;
            _wantToDash = false;
        }

        private void FixedUpdate()
        {
            _stateMachine.FixTick();
        }

        public void PlayAnimator(string stateName)
        {
            _animator.Play(stateName);
        }

        public void OnFire()
        {
            _wantToAttack = true;
        }

        public void OnDash()
        {
            _wantToDash = true;
        }

        public void OnMove(InputValue inputValue)
        {
            Movement = inputValue.Get<Vector2>();
        }
    }
}
