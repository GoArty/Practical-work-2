using PracticalWork2.Movement;
using PracticalWork2.Shooting;
using PracticalWork2.PickUp;
using UnityEngine;
using PracticalWork2.Baths;

namespace PracticalWork2
{
    [RequireComponent(typeof(CharacterMovementController), typeof(ShootingController))]

    public abstract class BaseCharacter : MonoBehaviour
    {
        [SerializeField]
        private Weapon _baseWeaponPrefab;

        [SerializeField]
        private Transform _hand;

        [SerializeField]
        private float _health = 2f;

        private bool _accelerationBonusWork = false;
        private float _remainAccelerationBonusSec = 0f;
        private float _accelerationMultiplier = 0f;

        private IMovementDirectionSource _movementDirectionSource;

        private CharacterMovementController _characterMovementController;
        private ShootingController _shootingController;


        protected void Awake()
        {
            _movementDirectionSource = GetComponent<IMovementDirectionSource>();

            _characterMovementController = GetComponent<CharacterMovementController>();
            _shootingController = GetComponent<ShootingController>();
        }

        protected void Start()
        {
            SetWeapon(_baseWeaponPrefab);
        }

        protected void Update()
        {
            var direction = _movementDirectionSource.MovementDirection;
            var lookDirection = direction;

            if (_shootingController.HasTarget)
                lookDirection = (_shootingController.TargetPosition - transform.position).normalized;

            _characterMovementController.MovementDirection = direction;
            _characterMovementController.LookDirection = lookDirection;

            BonusCheck();

            if (_health <= 0f)
                Destroy(gameObject);
        }

        protected void OnTriggerEnter(Collider other)
        {
            if(LayerUtils.IsBullet(other.gameObject))
            {
                var bullet = other.gameObject.GetComponent<Bullet>();
                _health -= bullet.Damage;

                Destroy(other.gameObject);
            }
            else if (LayerUtils.PickUpWeapon(other.gameObject))
            {
                var pickUpWeapon = other.gameObject.GetComponent<PickUpWeapon>();
                pickUpWeapon.PickUp(this);
                
                Destroy(other.gameObject);
            }
            else if (LayerUtils.PickUpBonus(other.gameObject))
            {
                var pickUpBonus = other.gameObject.GetComponent<PickUpBonus>();
                pickUpBonus.PickUp(this);

                Destroy(other.gameObject);
            }
        }

        public void SetWeapon(Weapon weapon) => _shootingController.SetWeapon(weapon, _hand);

        public void BonusCheck()
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

        public void SetBonus(Bonus bonusPrefab)
        {
            _accelerationBonusWork = true;
            _remainAccelerationBonusSec = bonusPrefab.AccelerationDurationSec;
            _accelerationMultiplier = bonusPrefab.AccelerationMultiplier;
        }        
    }
}