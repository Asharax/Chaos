using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject enemyObj;
    public int enemyCnt=0,i=0;
    public Transform[] enemyPos;
    public GameObject Player;
    public int enemyLimit = 100;
    public float MinEnemySize=0.5f;
    int eHP,eDamage;
    Playerinf Pinfo;
    Vector3 eScale;

    private void Start()
    {
        eHP =enemyObj.GetComponent<EnemyInfo>().EnemyHp;
        eDamage = enemyObj.GetComponent<EnemyInfo>().EnemyDamage;

        Pinfo = Player.GetComponent<Playerinf>();
        eScale = gameObject.transform.localScale;
    }
    private void DamageEnemy(GameObject obj ,int dmg)
    {
        Debug.Log("eHP: " + eHP);
        if (eHP > 0)
        {
            eHP -= dmg;
        }
        if (eHP <= 0 && this.gameObject != null)
        {
            if (this.gameObject.transform.localScale.x >= MinEnemySize)
            {
                EnemyGenerator enemyGen =  gameObject.AddComponent<EnemyGenerator>();
                enemyGen.GenerateEnemy(this.gameObject, enemyPos, 2);
                Destroy(obj);
                enemyCnt++; 
            }
            else {
                Destroy(obj);
            }
        
        }

    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            DamageEnemy(this.gameObject,Pinfo.playerDmg);
            if (eScale.x >= MinEnemySize)
                transform.localScale = new Vector3(eScale.x * MinEnemySize, eScale.y * MinEnemySize, 0);
        }

        else if (collision.gameObject.CompareTag("Player"))
        {   
                DamageEnemy(this.gameObject, Pinfo.playerDmg);
                Pinfo.DamagePlayer(eDamage);
        }

        Debug.Log("Enemy info:" + eHP);
        

    }
}

