using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour, ITargetable
{
    public State TargetIndex { get; set; }
    public void PrintText()
    {
        print("Target");
    }
}
