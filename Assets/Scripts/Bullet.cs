using System;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private Tilemap backgroundPrefab;

    internal float Damage;
    
    private Rigidbody2D _rigidbody;
    private bool _shoot;

    private Vector2 _maxBounds;
    private Vector2 _minBounds;

    internal void Shoot()
    {
        _shoot = true;
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        transform.localRotation *= Quaternion.Euler(0,0,-90);
        GetMaxBounds();
    }

    private void GetMaxBounds()
    {
        var cellBounds = backgroundPrefab.cellBounds;
        _maxBounds = new Vector2(cellBounds.max.x, cellBounds.max.y);
        _minBounds = new Vector2(cellBounds.min.x, cellBounds.min.y);
    }

    private void Update()
    {
        if (transform.position.x > _maxBounds.x || transform.position.x < _minBounds.x)
        {
            Destroy(gameObject);
        }

        if (transform.position.y > _maxBounds.y || transform.position.y < _minBounds.y)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        if (!_shoot) return;
        _rigidbody.velocity = transform.TransformDirection(Vector2.up * moveSpeed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().TakeDamage(Damage);
            Destroy(gameObject);
        }
    }
}
