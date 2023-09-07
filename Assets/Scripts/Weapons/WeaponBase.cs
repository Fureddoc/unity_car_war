using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{
    
    public float duration = 0.5f;
    public Character owner;
    public float damage = 10;
    
    // Start is called before the first frame update
    void Start()
    {
        StartAttack();
    }

    private void StartAttack()
    {
        InvokeRepeating("Attack", 0, duration);
    }

    // Update is called once per frame
    protected abstract void Attack();
    
    public void StopAttack()
    {
        CancelInvoke("Attack");
    }
}
