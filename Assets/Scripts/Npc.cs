using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc : MonoBehaviour, ITargetable
{
    public State TargetIndex { get; set; }
    public void PrintText()
    {
        print("npc");
    }
}
