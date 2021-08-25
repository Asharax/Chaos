using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Playerinf : MonoBehaviour
{
    public GameObject PlayerObj;

    public struct Player
    {
        public static int Hp = 100;
        public static float Speed = 2000;
        public static int Dmg = 50;

    }
    void Update()
    {
        Debug.Log("Player HP:"+Player.Hp);

        if (Player.Hp <= 0)
        {
            //restart the game & death screen
            //SceneManager.LoadScene("Main Menu");
            Debug.Log("Gameover!");

        }
    }
    public void DamagePlayer(int Dmg)
    {
        Player.Hp -= Dmg;
    }
}