using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject enemyObj;
    public Transform[] enemyPos;
    int i;
    void Start()
    {
        Debug.Log("EnemyGenerator.");
        EnemyMovement.GenerateEnemy(enemyObj, enemyPos);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            i= Random.Range(0, 5);
            EnemyMovement.GenerateEnemy(enemyObj,enemyPos,i);
        }
    }
}

