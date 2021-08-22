using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Vector2 cord;

    public GameObject obj;
    public float Speed = 200f;
    public Transform FirePoint;
    //private Transform FirePoint2;

    private GameObject prefab;
    public GameObject Bullet;
    private Vector2 force = new Vector2(500f,0);
    void Start()
    {
        cord = obj.transform.position;
        //FirePoint2 = FirePoint;
    }
    void Fire()
    {
        prefab = GameObject.Instantiate(Bullet, FirePoint);
        prefab.GetComponent<Rigidbody2D>().AddForce(force, 0);
        //prefab = GameObject.Instantiate(Bullet, FirePoint2);
        //prefab.GetComponent<Rigidbody2D>().AddForce(force, 0);
    }
    void Update()
    {
        obj.GetComponent<Rigidbody2D>().MovePosition(cord);
        if (Input.GetAxisRaw("Horizontal")!=0)
        {
           cord.x += Input.GetAxisRaw("Horizontal")* Speed *Time.deltaTime;
        }
        if (Input.GetAxisRaw("Vertical") != 0)
        {
            cord.y += Input.GetAxisRaw("Vertical") * Speed * Time.deltaTime;
        }
        if (Input.GetButtonDown("Space"))
        {
            Fire();
        }
    }
   
}
