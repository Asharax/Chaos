using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Wall"))
        {
           // EnemyMovement.EnemySpawn();
            Destroy(bullet,0);
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(bullet, 0);
            //enemy'i küçült
        }
    }
}
