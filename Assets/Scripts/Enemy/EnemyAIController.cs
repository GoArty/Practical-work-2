using PracticalWork2.Enemy.States;
using UnityEngine;

namespace PracticalWork2.Enemy
{
    public class EnemyAIController : MonoBehaviour
    {
        [SerializeField]
        private float _viewRadius = 20f;

        private EnemyTarget _target;
        private EnemyStateMachine _stateMachine;

        protected void Awake()
        {
            var player = FindObjectOfType<PlayerCharacter>();

            var enemyDirectionController = GetComponent<EnemyDirectionController>();

            var navMesher = new NavMesher(transform);
            _target = new EnemyTarget(transform, player, _viewRadius);

            _stateMachine = new EnemyStateMachine(enemyDirectionController, navMesher, _target);
        }

        protected void Update()
        {
            _target.FindClosest();
            _stateMachine.Update();
        }
    }
}