using UnityEngine;
using UnityEngine.AI;

namespace PracticalWork2.Enemy
{
    public class NavMesher
    {
        private const float DistanceEps = 1.5f;

        public bool IsPathCalculated {  get; private set; }

        private readonly NavMeshQueryFilter _filter;
        private readonly Transform _agentTransform;

        private NavMeshHit _targetHit;
        private NavMeshPath _navMeshPath;
        private int _currentPathPointIndex;

        public NavMesher(Transform agentTransform)
        {
            _filter = new NavMeshQueryFilter { areaMask = NavMesh.AllAreas };
            IsPathCalculated = false;
            _agentTransform = agentTransform;
        }

        public void CalculatePath(Vector3 targetPosition)
        {
            NavMesh.SamplePosition(_agentTransform.position,out var agentHit, 10f, _filter);
            NavMesh.SamplePosition(targetPosition, out _targetHit, 10f, _filter);

            IsPathCalculated = NavMesh.CalculatePath(agentHit.position, _targetHit.position, _filter, _navMeshPath);
            _currentPathPointIndex = 0;
        }

        public Vector3 GetCurrentPoint()
        {
            var currentPoint = _navMeshPath.corners[_currentPathPointIndex];
            var distance = (_agentTransform.position -currentPoint).magnitude;

            if(distance < DistanceEps)
                _currentPathPointIndex++;

            if (_currentPathPointIndex >= _navMeshPath.corners.Length)
                IsPathCalculated = false;
            else
                currentPoint = _navMeshPath.corners[_currentPathPointIndex];

            return currentPoint;
        }

        public float DistanceToTargetPointFrom(Vector3 position) => (_targetHit.position - position).magnitude;

    }
}