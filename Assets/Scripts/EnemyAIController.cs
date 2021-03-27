using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class EnemyAIController : MonoBehaviour
{

    [SerializeField] private GameObject targetObject = null;
    [SerializeField] private List<GameObject> targetObjects= new List<GameObject>();
    
    [SerializeField] private Vector3 targetPosition = default;
    [SerializeField] private float movementSpeed = 10f;

    private bool isTargetObject = false;
    private bool isReachedTarget = false;
    [SerializeField] private bool canLoop = false;

    private int targetObjetIndex = 0;
    
    void Start()
    {
        if (targetObject != null)
        {
            isTargetObject = true;
        }
        else if (targetObjects.Count > 0)
        {
            isReachedTarget = false;
            targetPosition = targetObjects[targetObjetIndex].transform.position;
        }
    }
    
    private void Update()
    {
        var currentPosition = transform.position;

        if (isTargetObject)
        {
            targetPosition = targetObject.transform.position;
            isTargetObject = false;
        }
        

        if (Vector3.Distance(currentPosition, targetPosition) <= 0.1f)
        {
            isReachedTarget = true;
            targetObject = null;
        }
        else
        {
            var slerp = movementSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(currentPosition, targetPosition, slerp);
        }

        if (isReachedTarget)
        {
            // Idle State
            targetObject = null;
        }

        // For list
        if (targetObjects.Count > 0)
        {
            if (isReachedTarget)
            {
                if (targetObjects.Count > targetObjetIndex+1)
                {
                    targetObjetIndex += 1;
                    targetPosition = targetObjects[targetObjetIndex].transform.position;
                }
                else if (canLoop)
                {
                    targetObjetIndex = 0;
                    targetPosition = targetObjects[targetObjetIndex].transform.position;
                }

                isReachedTarget = false;
            }
        }
    }

    public void SetTargetPosition(GameObject targetPos)
    {
        targetObject = targetPos;
        isTargetObject = true;
    }
}
