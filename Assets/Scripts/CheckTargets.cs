using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTargets : MonoBehaviour
{
    [SerializeField] private EnemyAIController enemyAIController;
    
    private void OnTriggerEnter(Collider other)
    {
        // if (other.CompareTag("Target"))
        // {
        //     enemyAIController.SetTargetPosition(other.gameObject);
        //     print("aaaa");
        // }
        //
        // if (other.GetComponent<Target>() != null)
        // {
        //     enemyAIController.SetTargetPosition(other.gameObject);
        //     print("aaaa");
        // }
        //
        // if (other.GetComponent<Npc>() != null)
        // {
        //     enemyAIController.SetTargetPosition(other.gameObject);
        //     print("aaaa");
        // }
        
        // ------ 
        
        if (other.GetComponent<ITargetable>() != null || other.CompareTag("Target"))
        {
            enemyAIController.SetTargetPosition(other.gameObject);
            other.GetComponent<ITargetable>().PrintText();
        }
        
    }
}
