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

    private void DamageEnemy(GameObject obj ,int dmg)
    {
        Debug.Log("EnemyHP: " + EnemyInfo.Enemy.Hp);
        if (EnemyInfo.Enemy.Hp > 0)
        {
            EnemyInfo.Enemy.Hp -= dmg;
        }
        if (EnemyInfo.Enemy.Hp <= 0 && this.gameObject != null)
        {

            //NEW Problem, might need fixing.
            EnemyGenerator enemyGen = new EnemyGenerator();
            enemyGen.GenerateEnemy(this.gameObject, enemyPos, 2);

            transform.localScale = new Vector3(this.gameObject.transform.localScale.x * (EnemyInfo.Enemy.Hp / 100), this.transform.localScale.y * (EnemyInfo.Enemy.Hp / 100), 0);

            Destroy(obj);
            //enemyCnt--;
            //enemyCnt++;
            enemyCnt++;
        }

    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Bullet") && EnemyInfo.Enemy.Hp > 0)
         {
                DamageEnemy(this.gameObject,Playerinf.Player.Dmg);
                transform.localScale = new Vector3(this.gameObject.transform.localScale.x * 0.75f, this.gameObject.transform.localScale.y * 0.75f, 0);
         }

        else if (collision.gameObject.CompareTag("Player"))
        {   
                DamageEnemy(this.gameObject,Playerinf.Player.HitDmg);
                Playerinf.DamagePlayer(EnemyInfo.Enemy.Damage);
        }

        Debug.Log("Enemy info:" + EnemyInfo.Enemy.Hp);
        

    }
}

