﻿using System;

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
        private Vector2 _movement;
        public Vector2 Movement => _movement;
        public float Direction { get; set; }
        private StateMachine _stateMachine;
        private Animator _animator;
        private bool _wantToAttack;

        private void Awake()
        {
            _animator = GetComponentInChildren<Animator>();

            _stateMachine = new StateMachine();

            var attack = new PlayerAttackState(this);
            var movement = new PlayerMovementState(this, _animator, GetComponent<Rigidbody2D>());

            At(movement, attack, () => _wantToAttack);
            At(attack, movement, () => !_animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"));

            _stateMachine.SetState(movement);

            void At(IState to, IState from, Func<bool> condition) => _stateMachine.AddTransition(to, from, condition);
        }

        private void Update()
        {
            _stateMachine.Tick();
            _wantToAttack = false;
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

        public void OnMove(InputValue inputValue)
        {
            _movement = inputValue.Get<Vector2>();
        }
    }
}
