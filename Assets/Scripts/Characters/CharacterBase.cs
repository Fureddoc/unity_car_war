using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBase : MonoBehaviour
{

    // ステータス　Status
    public float health = 100;
    public float defeat = 0;
    public bool isDead = false;
    protected bool isAutoDestroy = true;
    [SerializeField]
    protected float baseDamage = 0;
    
    public GameObject weapons = null;

    protected GameManager gameManager;
    protected UIManager uiManager;
    protected ControllerBase controller;
    
    // Required Components
    public SpriteRenderer spriteRenderer;

    // VFX
    public GameObject deathEffect;

    protected void Start()
    {
        gameManager = GameObject.Find("_Managers").GetComponent<GameManager>();
        uiManager = gameManager.gameObject.GetComponent<UIManager>();
    }

    public void ApplyDamage(CharacterBase dealer, float damage)
    {
        // ダメージ計算　simple damage calculator
        float finalDamage = Mathf.Max(0, damage - defeat);

        health -= finalDamage;

        // Debug.Log(this+" -"+ finalDamage + " HP");
        if(health <= 0)
        {
            // handle dealth
            OnDead(dealer);
        }
        else
        {
            StartCoroutine(HitEffect(Color.red));
        }
    }

	// 死亡処理
    protected virtual void OnDead(CharacterBase dealer)
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        isDead = true;
        if(weapons!=null)
            weapons.SendMessage("StopAttack");
        if(isAutoDestroy) Destroy(gameObject);
    }

    protected IEnumerator HitEffect(Color color)
    {
        spriteRenderer.color = color;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = Color.white;
    }
    
    public void Attack(CharacterBase target, WeaponBase hitWeapon)
    {
        Debug.Log("Attack to "+target+"!");
        float finalDamage = baseDamage;
        if(hitWeapon!=null) finalDamage += hitWeapon.damage;
        target.ApplyDamage(this, finalDamage);
    }

    public void Move(Vector3 velocity)
    {
        transform.position += velocity;
    }
}
