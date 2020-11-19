using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBullet : MonoBehaviour, IpooledObject
{
    Rigidbody2D rb;
    playerControl target;
    Vector2 shootDirection;
    objectPooler objectPooler;

    public float bulletSpeed = 2.5f; 
    public float despawnTimer = 3f;

    public void OnObjectSpawn(){
        
        objectPooler = objectPooler.Instance;
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindObjectOfType<playerControl>();

        shootDirection = (target.transform.position - transform.position).normalized * bulletSpeed;
		rb.velocity = shootDirection * bulletSpeed;
        rb.transform.Rotate(0, 0, Mathf.Atan2(shootDirection.y, shootDirection.x) * Mathf.Rad2Deg + 90);
    }

    void Update(){
        despawnTimer -= Time.deltaTime;
        if (despawnTimer < 0 ){
            gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision){
        gameObject.SetActive(false);
        objectPooler.SpawnFromPool("explosion8", transform.position, Quaternion.identity);
    }

}
