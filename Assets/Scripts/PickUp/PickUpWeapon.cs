using PracticalWork2.Shooting;
using UnityEngine;

namespace PracticalWork2.PickUp
{
    public class PickUpWeapon : PickUpItem
    {
        [field: SerializeField]
        public Weapon _weaponPrefab;

        public override void PickUp(BaseCharacter character)
        {
            base.PickUp(character);
            character.SetWeapon( _weaponPrefab );
        }
    }
}