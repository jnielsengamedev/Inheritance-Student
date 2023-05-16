using System.Collections;
using UnityEngine;

namespace Pickups
{
    public class SpeedPickup : Pickup
    {
        public float speedToAdd;
        public float duration;
        
        protected override void Activate(PlayerController player)
        {
            StartCoroutine(SpeedCoroutine(player));
        }

        private IEnumerator SpeedCoroutine(PlayerController player)
        {
            // Make it look like the SpeedPickup has disappeared.
            DisableSpeedVisibility();
            // Store the original MoveSpeed; 
            var originalSpeed = player.MoveSpeed;
            // Add the speedToAdd float to the MoveSpeed.
            player.MoveSpeed += speedToAdd;
            // Wait for a set duration.
            yield return new WaitForSeconds(duration);
            // Restore the original MoveSpeed.
            player.MoveSpeed = originalSpeed;
            // Destroy the GameObject.
            Destroy(gameObject);
        }

        private void DisableSpeedVisibility()
        {
            _collider.enabled = false;
            _sprite.enabled = false;
        }
    }
}