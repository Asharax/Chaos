using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject enemyObj;
    public static int i = 0,enemyCnt=0;
    public static GameObject prefab;
    public Transform[] enemyPos;
    public GameObject Player;
    static int enemyLimit = 400;



    public struct Enemy
    {
        public static int Hp;
        public static float Speed;
        public static int Damage ;
        
    }
    private void Start()
    {
        Enemy.Hp = 100;
        Enemy.Speed = 6000;
        Enemy.Damage = 100;
    }
    private void Update()
    {
        Debug.Log("Enemy info:" + Enemy.Hp);
        if (Enemy.Hp <= 0)
        {
            GenerateEnemy(enemyObj, enemyPos);
            GenerateEnemy(enemyObj, enemyPos);

            prefab.transform.localScale = new Vector3(prefab.transform.localScale.x * 0.75f, prefab.transform.localScale.y * 0.75f, 0);

            if (!prefab.GetComponent<CircleCollider2D>().enabled)
            {
                prefab.GetComponent<CircleCollider2D>().enabled = !prefab.GetComponent<CircleCollider2D>().enabled;
            }
            Destroy(enemyObj);
        }

    }
    private void DamageEnemy(int dmg)
    {
        Debug.Log("EnemyHP: " + Enemy.Hp);
        if (Enemy.Hp > 0)
        {
            Enemy.Hp -= dmg;
        }   
    }
    public static void GenerateEnemy(GameObject enemyObj, Transform[] enemyPos)
        {
        if (enemyCnt < enemyLimit) { 
            prefab = GameObject.Instantiate(enemyObj, enemyPos[i%8].position, Quaternion.identity);
            enemyCnt++;
            Debug.Log(enemyCnt);
            i++;
            if (prefab != null)
            {
                prefab.GetComponent<Rigidbody2D>().AddForce(new Vector2(-Enemy.Speed * Time.deltaTime, 0));
            }
        }
    }
    public static void GenerateEnemy(GameObject enemyObj, Transform[] enemyPos, int i)
    {
        if (enemyCnt < enemyLimit)
        {
            prefab = GameObject.Instantiate(enemyObj, enemyPos[i % 8].position, Quaternion.identity);
            enemyCnt++;
            Debug.Log("Enemy Counter:" + enemyCnt);
            i++;
            if (prefab != null)
            {
                prefab.GetComponent<Rigidbody2D>().AddForce(new Vector2(-Enemy.Speed * Time.deltaTime, 0));
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (prefab != null)
        {
            if (collision.gameObject.CompareTag("Bullet") && Enemy.Hp > 0)
            {
                DamageEnemy(Playerinf.Player.Dmg);
                prefab.transform.localScale = new Vector3(prefab.transform.localScale.x * 0.75f, prefab.transform.localScale.y * 0.75f, 0);
            }
        }
       
        else if (collision.gameObject.CompareTag("Player"))
        {
            DamageEnemy(Playerinf.Player.Dmg);
            Player.GetComponent<Playerinf>().DamagePlayer(Enemy.Damage);
            Destroy(enemyObj);
        }    
    }
}

