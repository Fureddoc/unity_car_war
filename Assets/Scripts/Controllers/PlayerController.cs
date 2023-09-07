using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : ControllerBase
{
    
    // private bool bCanAttack = true;
    // private float attackCoolDown = 1;

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
    }

    void FixedUpdate()
    {
        if (!character.isDead)
        {
            Vector3 vec = (transform.right * Input.GetAxis("Horizontal") + transform.up * Input.GetAxis("Vertical"))
                * moveSpeed * Time.deltaTime;

            character.Move(vec);
        }
    }
}
