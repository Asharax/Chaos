using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInfo : MonoBehaviour
{

    public struct Enemy
    {
        public static int Hp;
        public static float Speed;
        public static int Damage;

    }
    // Start is called before the first frame update
    void Start()
    {

        Enemy.Hp = 100;
        Enemy.Speed = 6000;
        Enemy.Damage = 100;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
