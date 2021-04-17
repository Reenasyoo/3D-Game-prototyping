using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orc : EnemyBase
{
    protected override void Attack()
    {
        print("Orc attacks");
    }

    public override void GetName()
    {
        // throw new NotImplementedException();
    }
}
