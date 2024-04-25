using PracticalWork2.Movement;
using UnityEngine;

namespace PracticalWork2.Baths
{
    public class BonusController : MonoBehaviour
    {
        private bool _accelerationBonusWork = false;
        private float _remainAccelerationBonusSec = 0f;
        private float _accelerationMultiplier = 0f;
        private CharacterMovementController _characterMovementController;

        protected void Update()
        {
            if (_accelerationBonusWork)
            {
                if (_remainAccelerationBonusSec > 0)
                {
                    _remainAccelerationBonusSec -= Time.deltaTime;
                    _characterMovementController.MovementDirection *= _accelerationMultiplier;
                }
                else
                {
                    _accelerationBonusWork = false;
                }
            }
        }

        public void SetBonus(Bonus bonusPrefab, CharacterMovementController characterMovementController)
        {
            _accelerationBonusWork = true;
            _remainAccelerationBonusSec = bonusPrefab.AccelerationDurationSec;
            _accelerationMultiplier = bonusPrefab.AccelerationMultiplier;
            _characterMovementController = characterMovementController;
        }
    }
}