using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public struct Player
    {
        public static int Hp = 100;
        public static float Speed = 2000;
    }
    void Update()
    {
        Debug.Log(Player.Hp);
    }
    public void DamagePlayer(int Dmg)
    {
        Player.Hp -= Dmg;
    }
}