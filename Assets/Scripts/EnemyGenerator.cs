using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : EnemyMovement
{
    public GameObject Enemy;
    int eSpeed;
    void Start()
    {
        eSpeed = Enemy.GetComponent<EnemyInfo>().EnemySpeed;
        Debug.Log("EnemyGenerator");
        GenerateEnemy(enemyObj, enemyPos, 1);
    }

    public GameObject GenerateEnemy(GameObject enemyObj, Transform[] enemyPos, int enemyAmount)
    {
        i = i % 8;
        while (enemyAmount > 0 && enemyCnt < enemyLimit)
        {
            enemyObj = GameObject.Instantiate(enemyObj, enemyPos[i].position, Quaternion.identity);
            Debug.Log("Enemy Counter:" + enemyCnt);
            if (enemyObj != null)
            {
                enemyObj.GetComponent<Rigidbody2D>().AddForce(new Vector2(-eSpeed * Time.deltaTime, 0));
            }
            enemyCnt++; i++; enemyAmount--;
        }
        return enemyObj;
    }

   
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            GenerateEnemy(enemyObj,enemyPos,1);
        }
    }
}

