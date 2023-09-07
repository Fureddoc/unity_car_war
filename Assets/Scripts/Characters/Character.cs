using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : CharacterBase
{

    private int killCount;


    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        
        controller = GetComponent<PlayerController>();
        
        // プレイヤーなので、自動的に削除するフラグをfalseにする disable auto destroy
        isAutoDestroy = false;
        killCount = 0;
    }

    protected override void OnDead(CharacterBase dealer)
    {
        base.OnDead(dealer);
        // キャラクターを手動で削除する　end the game and destroy the character manually
        Debug.Log("End Game");
        gameManager.EndGame();
        Destroy(gameObject, 0.1f);
    }
   
    public void UpdateKillCount()
    {
        killCount++;
        uiManager.UpdateKillCount(killCount);
    }
}
