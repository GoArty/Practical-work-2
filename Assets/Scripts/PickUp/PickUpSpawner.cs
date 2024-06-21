using UnityEditor;
using UnityEngine;

namespace PracticalWork2.PickUp
{
    public class PickUpSpawner : MonoBehaviour
    {

        [SerializeField]
        private PickUpItem _pickUpPrefab;

        [SerializeField]
        private float _range = 2f;

        [SerializeField]
        private int _maxCount = 2;

        [SerializeField]
        private float _spawnIntervalSecondMax = 20f;

        [SerializeField]
        private float _spawnIntervalSecondMin = 5f;

        private float _spawnIntervalSecond = 0f;

        private float _currentSpawnTimeSeconds;
        private int _currentCount;

        protected void Update()
        {
            Random.InitState(System.DateTime.Now.Second);
            if (_currentCount < _maxCount)
            {
                _currentSpawnTimeSeconds += Time.deltaTime;
                if (_currentSpawnTimeSeconds > _spawnIntervalSecond)
                {
                    _currentSpawnTimeSeconds = 0f;
                    _spawnIntervalSecond = Random.Range(_spawnIntervalSecondMin, _spawnIntervalSecondMax);
                    _currentCount++;

                    var randomPointInsideRange = Random.insideUnitCircle * _range;
                    var randomPosition = new Vector3(randomPointInsideRange.x, 0f, randomPointInsideRange.y) + 
                        transform.position;

                    var pickUp = Instantiate(_pickUpPrefab, randomPosition, Quaternion.identity, transform);
                    pickUp.OnPickUp += OnItemPickedUp;
                }
            }
        }

        private void OnItemPickedUp(PickUpItem pickUpItem)
        {
            _currentCount--;
            pickUpItem.OnPickUp -= OnItemPickedUp;
        }

        private void OnDrawGizmos()
        {
            var cashedColor = Handles.color;
            Handles.color = Color.green;
            Handles.DrawWireDisc(transform.position, Vector3.up, _range);
            Handles.color = cashedColor;
        }
    }
}