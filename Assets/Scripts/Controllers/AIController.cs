using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : ControllerBase
{
    
    public float attackCoolDown;
    private float attackTimer;
    private bool resetTimer = false;

    public Character player;
    private bool bInAttack = false;
    
    
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        
        // Find player character
        var go = GameObject.FindGameObjectWithTag("Player");
        if(go!=null)
            player = go.GetComponent<Character>();

        Debug.Log(gameManager.isEnded);
    }

    // Update is called once per frame
    void Update()
    {

        if (gameManager.isEnded) return;

        if (player == null) return;
        if (bInAttack)
        {
            if (!resetTimer)
            {
                attackTimer = attackCoolDown;
                resetTimer = true;
            }

            attackTimer += Time.deltaTime;

            // 一定の間隔で攻撃する　attack logic here
            if (attackTimer > attackCoolDown)
            {
                character.Attack(player, null);
                attackTimer = 0;
            }
        }
        else
        {
            // いつもプレイヤーに向いている　keep tracing player
            var dir = (player.transform.position - transform.position).normalized;
            character.Move(dir * moveSpeed * Time.deltaTime);
        }
    }

    public void SwitchToAttackMode()
    {
        resetTimer = false;
        bInAttack = true;
    }

    public void SwitchToChaseMode()
    {
        resetTimer = false;
        bInAttack = false;
    }
}
