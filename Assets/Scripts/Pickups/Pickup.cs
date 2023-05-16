using UnityEngine;

namespace Pickups
{
    public abstract class Pickup : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player")) return;
            var player = other.GetComponent<PlayerController>();
            Activate(player);
            Destroy(gameObject);
        }

        protected virtual void Activate(PlayerController player)
        {
        }
    }
}