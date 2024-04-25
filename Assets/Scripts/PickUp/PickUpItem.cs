using PracticalWork2.Shooting;
using System;
using UnityEngine;

namespace PracticalWork2.PickUp
{
    public abstract class PickUpItem : MonoBehaviour
    {
        public event Action<PickUpItem> OnPickUp;

        public virtual void PickUp(BaseCharacter character)
        {
            OnPickUp?.Invoke(this);
        }
    }
}