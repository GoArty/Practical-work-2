using UnityEngine;


namespace PracticalWork2.Baths
{
    public class Bonus : MonoBehaviour
    {
        [field: SerializeField]
        public float AccelerationDurationSec { get; private set; } = 15f;

        [field: SerializeField]
        public float AccelerationMultiplier { get; private set; } = 2f;

    }
}