using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public static GameObject Enemy;
    public GameObject prefab;//,prefab2;

    public Transform enemyPos;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet") && prefab.transform.localScale.x >= 0.25)
        {
            Destroy(Enemy);

            prefab = GameObject.Instantiate(Enemy);

            prefab.transform.localScale=new Vector3(prefab.transform.localScale.x*0.75f, prefab.transform.localScale.y*0.75f,0);
            prefab.GetComponent<CircleCollider2D>().enabled=!prefab.GetComponent<CircleCollider2D>().enabled;

            //prefab2 = GameObject.Instantiate(Enemy, enemyPos);
            //prefab2.transform.localScale = prefab.transform.localScale;
            //prefab2.GetComponent<CircleCollider2D>().enabled = !prefab2.GetComponent<CircleCollider2D>().enabled;

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
