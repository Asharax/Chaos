using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInfo : MonoBehaviour
{
    public int EnemyHp,EnemySpeed,EnemyDamage;

    void Start()
    {
        EnemyHp = 100;
        EnemySpeed = 60000;
        EnemyDamage = 100;
    }
}
