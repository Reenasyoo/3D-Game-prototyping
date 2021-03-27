using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Troll : EnemyBase
{
    private void Awake()
    {
        base.Awake();
    }
    
    protected override void Attack()
    {
        print("Troll attacks");
    }

    public override void GetName()
    {
        print(_data.enemyName);
    }
}


public class WepBase
{
    public string wepName;

    public WepBase(string name, int id)
    {
        wepName = name;
    }
}


public class Wep1 : WepBase
{
    public Wep1(string name, int id) : base(name, id)
    {
        wepName = name;
    }
}