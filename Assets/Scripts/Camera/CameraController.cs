using System;
using UnityEngine;

namespace PracticalWork2.Camera
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField]
        private Vector3 _followCameraOffset = Vector3.zero;

        [SerializeField]
        private Vector3 _rotationOffset = Vector3.zero; 

        [SerializeField]
        private PlayerCharacter _player;

        protected void Awake()
        {
            if (_player == null)
                throw new NullReferenceException($"Follow camera can't follow null player - {nameof(_player)}");
        }


        protected void LateUpdate()
        {
            if( _player != null )
            {
                Vector3 targetRotation = _rotationOffset - _followCameraOffset;

                transform.position = _player.transform.position + _followCameraOffset;
                transform.rotation = Quaternion.LookRotation(targetRotation, Vector3.up);
            }
        }
    }
}