using TheCoP.Architecture.Interfaces.State_Machines;

using UnityEngine;

namespace TheCoP.Scripts__components_.Entities.AI
{
    public class SimpleAI : MonoBehaviour
    {
        [SerializeField] private float distance = 4f;
        [SerializeField] private float attackRange = 1f;

        private const string PlayerTag = "Player";
        private GameObject[] enemies;
        private IInputStateMachine _stateMachine;

        private void Awake()
        {
            enemies = GameObject.FindGameObjectsWithTag(PlayerTag);
            _stateMachine = GetComponent<IInputStateMachine>();
        }

        private void Update()
        {
            var myPos = transform.position;
            var (nearestEnemy, enemyDistance) = FindNearestEnemy();

            if (nearestEnemy is null)
            {
                _stateMachine.OnMove(Vector2.zero);
                return;
            }

            var transformPosition = nearestEnemy.transform.position;
            var move = new Vector2(transformPosition.x - myPos.x, transformPosition.y - myPos.y);
            if (enemyDistance < attackRange)
            {
                _stateMachine.OnFire();
            }
            move.Normalize();
            _stateMachine.OnMove(move);
        }

        private (GameObject, float) FindNearestEnemy()
        {
            var myPos = transform.position;
            var minDistance = distance;
            GameObject nearestEnemy = null;
            foreach (var enemy in enemies)
            {
                var currentDistance = Vector3.Distance(myPos, enemy.transform.position);
                if (currentDistance > minDistance) continue;
                minDistance = currentDistance;
                nearestEnemy = enemy;
            }
            return (nearestEnemy, minDistance);
        }
    }
}
