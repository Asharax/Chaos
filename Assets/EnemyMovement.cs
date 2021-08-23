using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject EnemyObj;
    private int i = 0;
    public GameObject prefab;
    public Transform[] enemyPos;
    public struct Enemy{
        public static int Hp=100;
        public static float Speed=300;
    }
    private void GenerateEnemy()
    {
        if (i <= 5 && i >= 0)
        {
            prefab = GameObject.Instantiate(EnemyObj, enemyPos[i].position, Quaternion.identity);
            i++;
        }
        else if(i>5 && i < 0)
        {
            i = 0;
        }
        if (prefab != null)
        {
            prefab.GetComponent<Rigidbody2D>().AddForce(new Vector2(-Enemy.Speed * Time.deltaTime, 0));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (prefab != null)
        {
            if (prefab != null && collision.gameObject.CompareTag("Bullet") && Enemy.Hp > 0)
            {
                GenerateEnemy();
                GenerateEnemy();

                prefab.transform.localScale = new Vector3(prefab.transform.localScale.x * 0.75f, prefab.transform.localScale.y * 0.75f, 0);

                if (!prefab.GetComponent<CircleCollider2D>().enabled)
                {
                    prefab.GetComponent<CircleCollider2D>().enabled = !prefab.GetComponent<CircleCollider2D>().enabled;
                }
                Destroy(EnemyObj);

                //prefab2 = GameObject.Instantiate(temp, Vector3.zero, Quaternion.identity, transform);

                //prefab2.transform.localScale = new Vector3(prefab.transform.localScale.x * 0.75f, prefab.transform.localScale.y * 0.75f, 0);
                //prefab2.GetComponent<CircleCollider2D>().enabled = !prefab.GetComponent<CircleCollider2D>().enabled;


            }
            else if (collision.gameObject.CompareTag("Player"))
                {
                //player will lose hp maybe give bomb for faster clear.
                Destroy(EnemyObj);
                }
            else 
            {
                Destroy(EnemyObj);
            }
        }
        else if(EnemyObj != null)
            Destroy(EnemyObj);

        return;
     }
}

