using System;
using UnityEngine;

public class PistolWeapon : Weapon
{
    [SerializeField] private GameObject bulletPrefab;

    private Collider2D _collider;

    private void Awake()
    {
        _collider = GetComponent<Collider2D>();
    }

    public override void Attack()
    {
        if (!Instantiate(bulletPrefab,
                    new Vector3(_collider.bounds.center.x + _collider.bounds.extents.x, _collider.bounds.center.y),
                    transform.rotation)
                .TryGetComponent<Bullet>(out var bullet)) return;

        bullet.Damage = damage;
        bullet.Shoot();
    }
}