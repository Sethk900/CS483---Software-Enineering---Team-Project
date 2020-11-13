using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerBullet : MonoBehaviour, IpooledObject
{
    Rigidbody2D rb;
    Vector2 shootDirection;

    public float bulletSpeed = 5f;
    public float despawnTimer = 3f;

    public void OnObjectSpawn(){

        rb = GetComponent<Rigidbody2D>();

        shootDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        rb.velocity = shootDirection * bulletSpeed;
		rb.transform.Rotate(0, 0, Mathf.Atan2(shootDirection.y, shootDirection.x) * Mathf.Rad2Deg + 90);
    }

    // Update is called once per frame
    void Update(){
        despawnTimer -= Time.deltaTime;
        if (despawnTimer < 0 ){
            gameObject.SetActive(false);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision){
        gameObject.SetActive(false);
    }

}
