using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    internal float Damage;
    
    private Rigidbody2D _rigidbody;
    private bool _shoot;

    internal void Shoot()
    {
        _shoot = true;
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (!_shoot) return;
        _rigidbody.velocity = Vector2.right * moveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().TakeDamage(Damage);
        }
    }
}
