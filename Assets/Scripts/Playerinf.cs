using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Playerinf : SceneManagement
{
    public GameObject PlayerObj;


    public struct Player
    {
        public static int Hp = 100;
        public static float Speed = 2000;
        public static int Dmg = 50;
        public static int HitDmg = 50;


    }
    void Update()
    {
        
        Debug.Log("Player HP:" +Player.Hp);
        if (Player.Hp <= 0)
        { 
            Debug.Log("Gameover!");
            Destroy(gameObject);
            ReloadScene();

        }
    }
    public static void DamagePlayer(int Dmg)
    {
        Player.Hp -= Dmg;
    }
}