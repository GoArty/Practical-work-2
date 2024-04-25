using UnityEngine;

namespace PracticalWork2.Movement
{
    [RequireComponent(typeof(CharacterController))]
    public class CharacterMovementController : MonoBehaviour
    {
        private static readonly float SqrEpsilon = Mathf.Epsilon * Mathf.Epsilon;

        [SerializeField]
        private float _speed = 1f;
        [SerializeField]
        private float _maxRadiansDelta = 10f;

        public Vector3 MovementDirection { get; set; }
        public Vector3 LookDirection { get; set; }

        private CharacterController _characterController;

        protected void Awake()
        {
            _characterController = GetComponent<CharacterController>();
        }

        protected void Update()
        {           
            Translate();

            if(_maxRadiansDelta > 0f && LookDirection != Vector3.zero)
                Rotate();
        }

        private void Translate()
        {
            var delta = MovementDirection * _speed * Time.deltaTime;
            _characterController.Move(delta);
        }

        private void Rotate()
        {
            var currentLoopDirection = transform.rotation * Vector3.forward;
            float sqrMagnitude = (currentLoopDirection - LookDirection).sqrMagnitude;

            if(sqrMagnitude > SqrEpsilon)
            {
                var newRotation = Quaternion.Slerp(
                    transform.rotation,
                    Quaternion.LookRotation(LookDirection, Vector3.up),
                    _maxRadiansDelta * Time.deltaTime);
                transform.rotation = newRotation;  
            }

        }
    }
}