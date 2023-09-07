using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : CharacterBase
{
    
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        controller = GetComponent<AIController>();
    }

    protected override void OnDead(CharacterBase dealer)
    {
        base.OnDead(dealer);
        // キル数更新　update kill count if killed by player
        (dealer as Character)?.UpdateKillCount();
    }
}
