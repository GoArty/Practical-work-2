using UnityEngine;

namespace PracticalWork2.Enemy
{
    public class EnemyTarget
    {
        public GameObject Closest { get; private set; }

        private readonly float _viewRadius; 
        private readonly Transform _agentTransform;
        private readonly PlayerCharacter _player;

        private readonly Collider[] _colliders = new Collider[10]; 

        public EnemyTarget(Transform agent, PlayerCharacter palyer, float viewRadius)
        {
            _agentTransform = agent;
            _player = palyer;
            _viewRadius = viewRadius;
        }

        public void FindClosest()
        {
            float minDistance = float.MaxValue;

            var count = FindAllTargets(LayerUtils.PickUpMask | LayerUtils.CharacterMask);

            for(int i = 0; i < count; i++)
            {
                var go = _colliders[i].gameObject;
                if (go == _agentTransform.gameObject) continue;

                var distance = DistanceFromAgentTo(go);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    Closest = go;
                }
            }

            if (_player != null && DistanceFromAgentTo(_player.gameObject) < minDistance)
                Closest = _player.gameObject;
        }

        public float DistanceToClosestEnemyAgent()
        {
            if(Closest != null)
                DistanceFromAgentTo(Closest);

            return 0;
        }

        private int FindAllTargets(int layerMask)
        {
            var size = Physics.OverlapSphereNonAlloc(
                _agentTransform.position,
                _viewRadius,
                _colliders,
                layerMask);
            return size;
        }
        private float DistanceFromAgentTo(GameObject go) => (_agentTransform.position - go.transform.position).magnitude;
    }
}