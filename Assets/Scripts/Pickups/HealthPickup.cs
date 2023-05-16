using UnityEngine;

namespace Pickups
{
    public class HealthPickup : Pickup
    { 
        public float healingAmount;

        protected override void Activate(PlayerController player)
        {
            player.Health = Mathf.Clamp(player.Health += healingAmount, 0, player.maxHealth);
            Destroy(gameObject);
        }
    }
}