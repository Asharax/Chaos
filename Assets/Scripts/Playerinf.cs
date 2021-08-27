using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Playerinf : SceneManagement
{
    public GameObject PlayerObj,Enemy;
    public Text TextHP;
    public int playerHP = 100;
    public int playerSpeed = 2000;
    public int playerDmg = 50;
    public int playerHitDmg = 50;
    int eDamage;

   private void Start()
    {
        eDamage = Enemy.GetComponent<EnemyInfo>().EnemyDamage;
    }
    void Update()
    {
        TextHP.text = "HP: " + playerHP.ToString();
        Debug.Log(TextHP.text.ToString());

        if (playerHP <= 0)
        { 
            Debug.Log("Gameover!");
            Destroy(gameObject);
            ReloadScene();

        }
    }
    public void DamagePlayer(int Dmg)
    {
        playerHP -= Dmg;

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            DamagePlayer(eDamage);
        }
    }
}