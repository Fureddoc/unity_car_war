using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRangeChecker : MonoBehaviour
{

    public AIController aIController;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            var player = collision.gameObject.GetComponent<Character>();
            aIController.SwitchToAttackMode();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        aIController.SwitchToChaseMode();
    }
}
