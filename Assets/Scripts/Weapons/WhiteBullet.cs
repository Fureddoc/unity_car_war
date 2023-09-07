using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteBullet : BulletBase
{
    
    public Vector2 direction;
    
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(direction*moveSpeed*Time.fixedDeltaTime);
    }
}
