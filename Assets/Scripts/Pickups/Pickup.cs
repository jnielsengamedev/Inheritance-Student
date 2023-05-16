using UnityEngine;

namespace Pickups
{
    [RequireComponent(typeof(Collider2D))]
    public abstract class Pickup : MonoBehaviour
    {
        private void Awake()
        {
            var pickupCollider = GetComponent<Collider2D>();
            pickupCollider.isTrigger = true;
        }

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