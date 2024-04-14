using UnityEngine;

namespace PracticalWork2
{
    public static class LayerUtils
    {
        public const string BulletLayerName = "Bullet";
        public const string PlayerLayerName = "Player";
        public const string EnemyLayerName = "Enemy";

        public static readonly int BulletLayer = LayerMask.NameToLayer(BulletLayerName);
        public static readonly int PlayerMask = LayerMask.GetMask(PlayerLayerName);//
        public static readonly int EnemyMask = LayerMask.GetMask(EnemyLayerName);

        public static bool IsBullet(GameObject other) => other.layer == BulletLayer;
    }
}
