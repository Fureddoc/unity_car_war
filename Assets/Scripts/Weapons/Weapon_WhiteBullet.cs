using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_WhiteBullet : WeaponBase
{

    public GameObject bulletPrefab;

    protected override void Attack()
    {

        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        var dir = (mousePos - transform.position).normalized;

        var go = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        var bullet = go.GetComponent<WhiteBullet>();
        bullet.weaponBullet = this;
        bullet.direction = dir;
        bullet.owner = owner;
    }
}
