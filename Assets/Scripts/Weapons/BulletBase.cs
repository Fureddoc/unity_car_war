using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBase : MonoBehaviour
{

    public WeaponBase weaponBullet;
    public float moveSpeed = 30;

    public Character owner;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (owner == null || collision == null) return;
        CharacterBase target = null;
        
        if (owner.gameObject.CompareTag("Enemy")&&collision.gameObject.CompareTag("Player"))
        {
            // if self is enemy -> hit player only
            target = collision.gameObject.GetComponent<CharacterBase>();
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            // if self is player -> hit enemy only
            target = collision.gameObject.GetComponent<CharacterBase>();
        }

        if (target == null) return;
        target.ApplyDamage(owner, weaponBullet.damage);
        Destroy(gameObject);
    }
}