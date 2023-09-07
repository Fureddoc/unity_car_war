using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BlueBullet : BulletBase
{
    
    private float _currentRadius;
    private Vector2 _centre;
    private float _angle;
    
    
    // Update is called once per frame
    void FixedUpdate()
    {
        if(owner == null) return;
        
        _centre = owner.transform.position;

        _currentRadius += 1f * Time.deltaTime;
        _angle += (moveSpeed / (_currentRadius * Mathf.PI * 2.0f)) * Time.deltaTime;

        var offset = new Vector2(Mathf.Sin(_angle), Mathf.Cos(_angle)) * _currentRadius;

        transform.position = _centre + offset;
    }
}
