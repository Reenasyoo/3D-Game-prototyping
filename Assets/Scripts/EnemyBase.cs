using System;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{

    private WepBase _wep;
    public EnemyData _data = new EnemyData();
    public Collider _collider;
    
    
    protected void Awake()
    {
        _collider = GetComponent<Collider>();
        _data = new EnemyData(name);

    }

    protected virtual void Attack()
    {
        print("Enemy attacks");
    }

    public abstract void GetName();

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            Attack();
        }
    }
}

[Serializable]
public class EnemyData
{
    public string enemyName = "Enemy Name";
    public int enemyLevel = 0;

    public EnemyData(string name = "")
    {
        enemyName = name;
    }
    
}
