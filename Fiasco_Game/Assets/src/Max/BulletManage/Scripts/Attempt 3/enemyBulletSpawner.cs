using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBulletSpawner : MonoBehaviour
{

    objectPooler objectPooler;
    public float spawnFreqDesired = 1f;
    private float spawnDelay = 10f;
    private float spawnFreq;
    public float kowabunga = 200f;


    private void Start(){
        objectPooler = objectPooler.Instance;
        spawnFreq = spawnDelay;
        spawner();
    }

    // Update is called once per frame
    void Update()
    {   
        // objectPooler.SpawnFromPool("EnemyBullet", transform.position, Quaternion.identity);
    }

    private void spawner(){
        while(kowabunga > 0){
            if(spawnFreq > 0){
                spawnFreq -= Time.deltaTime;
                kowabunga -= Time.deltaTime;
            }else{
                Debug.LogWarning("Fire!!");
                objectPooler.SpawnFromPool("EnemyBullet", transform.position, Quaternion.identity);
                spawnFreq = spawnFreqDesired;
            }
        }
    }

}
