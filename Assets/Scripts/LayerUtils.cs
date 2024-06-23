using UnityEngine;

namespace PracticalWork2
{
    public static class LayerUtils
    {
        public const string BulletLayerName = "Bullet";
        public const string PlayerLayerName = "Player";
        public const string PickUpWeaponLayerName = "PickUpWeapon";
        public const string PickUpBonusLayerName = "PickUpBonus";
        public const string EnemyLayerName = "Enemy";

        public static readonly int BulletLayer = LayerMask.NameToLayer(BulletLayerName);
        public static readonly int PickUpWeaponLayer = LayerMask.NameToLayer(PickUpWeaponLayerName);
        public static readonly int PickUpBonusLayer = LayerMask.NameToLayer(PickUpBonusLayerName);

        public static readonly int CharacterMask = LayerMask.GetMask(PlayerLayerName, EnemyLayerName);
        public static readonly int PickUpMask = LayerMask.GetMask(PickUpWeaponLayerName, PickUpBonusLayerName);

        public static bool IsBullet(GameObject other) => other.layer == BulletLayer;
        public static bool PickUpWeapon(GameObject other) => other.layer == PickUpWeaponLayer;
        public static bool PickUpBonus(GameObject other) => other.layer == PickUpBonusLayer;
    }
}
