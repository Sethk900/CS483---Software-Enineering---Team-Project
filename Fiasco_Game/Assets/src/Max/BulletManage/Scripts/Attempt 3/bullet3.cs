using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet3 : MonoBehaviour, IpooledObject
{
    public playerControl playerLocation;
    public float speed = 2f;

    private Vector2 shootDirection;


    public void OnObjectSpawn()
    {
        playerLocation = FindObjectOfType<playerControl>();
        shootDirection = playerLocation.rb.position * speed;
        shootDirection.Normalize();

        GetComponent<Rigidbody2D>().velocity = shootDirection;
        
    }
}
