using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBullet : MonoBehaviour, IpooledObject
{
    public float speed = 5f;
    Rigidbody2D rb;

    playerControl target;
    Vector2 shootDirection;

    public GameObject bulletExplode;

    [SerializeField]
    private BoxCollider2D boxCollider;

    private GameObject[] enemies;

    private float despawnTimer = 3f;

    public void OnObjectSpawn()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindObjectOfType<playerControl>();


        shootDirection = (target.transform.position - transform.position).normalized * speed;
		rb.velocity = shootDirection * speed;
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
        bulletExplode.transform.position = new Vector2(transform.position.x, transform.position.y - 1f);
        GameObject.Instantiate(bulletExplode);
    }

}
