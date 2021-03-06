using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITargetable
{
    State TargetIndex { get; set; }
    
    void PrintText();
}


public enum State
{
    IDLE,
    RUN,
    HIT
}