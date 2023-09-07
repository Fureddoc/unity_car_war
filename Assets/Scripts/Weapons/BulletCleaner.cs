using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCleaner : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var bullet = collision.gameObject.GetComponent<BulletBase>();

        if (bullet != null)
        {
            Destroy(collision.gameObject);
        }
    }
}
