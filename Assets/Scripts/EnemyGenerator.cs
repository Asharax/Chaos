using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : EnemyMovement
{
    public GameObject GenerateEnemy(GameObject enemyObj, Transform[] enemyPos, int enemyAmount)
    {
        while (enemyAmount > 0 && enemyCnt < enemyLimit)
        {
            enemyObj = GameObject.Instantiate(enemyObj, enemyPos[i % 8].position, Quaternion.identity);
            Debug.Log("Enemy Counter:" + enemyCnt);
            if (enemyObj != null)
            {
                enemyObj.GetComponent<Rigidbody2D>().AddForce(new Vector2(-EnemyInfo.Enemy.Speed * Time.deltaTime, 0));
            }
            enemyCnt++; i++; enemyAmount--;
        }
        return enemyObj;
    }

    void Start()
    {
        Debug.Log("EnemyGenerator.");
        GenerateEnemy(enemyObj, enemyPos,1);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            GenerateEnemy(enemyObj,enemyPos,1);
        }
    }
}

