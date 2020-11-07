using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBullet : MonoBehaviour, IpooledObject
{
    public float speed = 2f;
    Rigidbody2D rb;

    playerControl target;
    Vector2 shootDirection;


    public void OnObjectSpawn()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindObjectOfType<playerControl>();
        shootDirection = (target.transform.position - transform.position).normalized * speed;
        rb.velocity = new Vector2 (shootDirection.x, shootDirection.y); 
    }
}
