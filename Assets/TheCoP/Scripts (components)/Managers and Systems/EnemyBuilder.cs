using System;
using UnityEngine;

namespace TheCoP.Scripts__components_.Managers_and_Systems
{
    public class EnemyBuilder : MonoBehaviour
    {
        [SerializeField] private EnemyData data; //kaif
        private Animator animator;
        public void OnEnable()
        {
            animator = GetComponentInChildren<Animator>();
            animator.runtimeAnimatorController = data.AnimatorController;
        }
    }
}
