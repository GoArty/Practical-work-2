using PracticalWork2.Baths;
using UnityEngine;

namespace PracticalWork2.PickUp
{
    public class PickUpBonus : PickUpItem
    {
        [field: SerializeField]
        public Bonus _bonusPrefab;

        public override void PickUp(BaseCharacter character)
        {
            base.PickUp(character);
            character.SetBonus(_bonusPrefab);
        }
    }
}