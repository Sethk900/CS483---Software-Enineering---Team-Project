using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coconut : MonoBehaviour, IpooledObject
{
    Rigidbody2D rb;
    playerControl target;
    Vector2 shootDirection;
    objectPooler objectPooler;
    

    public float startAngle = 90f, endAngle = 270f;
    public float bulletSpeed = 1f;

    private float angleStep, angle;
    private float despawnTimer = 10f;
    private int fireCount = 0;

    public void OnObjectSpawn(){
        objectPooler = objectPooler.Instance;
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindObjectOfType<playerControl>();

        fire();
    }

    private void fire(){
    
        if (fireCount == 0){
            shootDirection = target.transform.position - transform.position;
            shootDirection = target.transform.InverseTransformDirection(shootDirection);
            angleStep = (endAngle - startAngle) / 10;
            angle = (Mathf.Atan2(shootDirection.y, shootDirection.x) * Mathf.Rad2Deg);// - startAngle;
        }

        float bulDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
        float bulDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);

        Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
        Vector2 bulDir = (bulMoveVector - transform.position).normalized * bulletSpeed;

        rb.velocity = bulDir * bulletSpeed;
        if (fireCount == 11){
            fireCount = 0;
        }else{
            fireCount ++;
        }
        angle += angleStep;
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
        objectPooler.SpawnFromPool("explosion8", transform.position, Quaternion.identity);
    }
}
