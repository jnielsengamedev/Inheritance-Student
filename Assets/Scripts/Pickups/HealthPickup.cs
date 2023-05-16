using UnityEngine;

namespace Pickups
{
    public class HealthPickup : Pickup
    { 
        public float healingAmount;

        protected override void Activate(PlayerController player)
        {
            player.health = Mathf.Clamp(player.health += healingAmount, 0, player.maxHealth);
        }
    }
}