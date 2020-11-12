using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBullet : MonoBehaviour, IpooledObject
{
    public float speed = .05f;
    Rigidbody2D rb;

    playerControl target;
    Vector2 shootDirection;


    public void OnObjectSpawn()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindObjectOfType<playerControl>();
        shootDirection = (target.transform.position - transform.position).normalized * speed;
        rb.velocity = new Vector2 (shootDirection.x, shootDirection.y); 
        rb.transform.Rotate(0, 0, Mathf.Atan2(shootDirection.y, shootDirection.x) * Mathf.Rad2Deg + 90);
    }
}
