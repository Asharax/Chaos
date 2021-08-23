using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject Enemy;
    GameObject temp;
    private int i = 0;
    public GameObject prefab,prefab2;
    public Transform[] enemyPos;

    private void GenerateEnemy()
    {
        if (i <= 5 && i >= 0)
        {
            prefab = GameObject.Instantiate(Enemy, enemyPos[i].position, Quaternion.identity);
            i++;
        }
        else if(i>5 && i < 0)
        {
            i = 0;
        }
        else
        {
            return;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet") && prefab.transform.localScale.x >= 0.5)
        {
            GenerateEnemy();
            GenerateEnemy();

            prefab.transform.localScale=new Vector3(prefab.transform.localScale.x*0.75f, prefab.transform.localScale.y*0.75f,0);

            if (!prefab.GetComponent<CircleCollider2D>().enabled)
            {
                prefab.GetComponent<CircleCollider2D>().enabled = !prefab.GetComponent<CircleCollider2D>().enabled;
            }
            Destroy(Enemy);

            //prefab2 = GameObject.Instantiate(temp, Vector3.zero, Quaternion.identity, transform);

            //prefab2.transform.localScale = new Vector3(prefab.transform.localScale.x * 0.75f, prefab.transform.localScale.y * 0.75f, 0);
            //prefab2.GetComponent<CircleCollider2D>().enabled = !prefab.GetComponent<CircleCollider2D>().enabled;


        }
        else
        {
            Destroy(Enemy);
        }
    }
    //public static void EnemySpawn()
    //{
    //    GameObject.Instantiate(Enemy);
    //}
}
