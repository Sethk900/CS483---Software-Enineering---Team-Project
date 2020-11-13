using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBulletSpawner : MonoBehaviour
{

    objectPooler objectPooler;
    public float spawnDelay = 1f;
    public float spawnFreq = 1f;
    private float shootCounter;

    private void Start(){
        objectPooler = objectPooler.Instance;
        shootCounter = spawnDelay;
    }

    // Update is called once per frame
    void Update()
    { 
        if(shootCounter > 0){
            shootCounter -= Time.deltaTime;
        }else{
            objectPooler.SpawnFromPool("EnemyBullet", transform.position, Quaternion.identity);
            shootCounter = spawnFreq;
        }
    }

}
