using UnityEngine;

namespace Pickups
{
    [RequireComponent(typeof(Collider2D))]
    public abstract class Pickup : MonoBehaviour
    {
        protected SpriteRenderer _sprite;
        protected Collider2D _collider;
        
        private void Awake()
        {
            _sprite = GetComponent<SpriteRenderer>();
            _collider = GetComponent<Collider2D>();
            _collider.isTrigger = true;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player")) return;
            var player = other.GetComponent<PlayerController>();
            Activate(player);
        }

        protected virtual void Activate(PlayerController player)
        {
        }
    }
}