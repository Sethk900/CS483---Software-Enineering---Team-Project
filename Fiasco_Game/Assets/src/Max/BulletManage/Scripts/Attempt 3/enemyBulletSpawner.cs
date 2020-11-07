using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBulletSpawner : MonoBehaviour
{

    objectPooler objectPooler;
    public float spawnFreqDesired = .25f;
    private float spawnFreq;

    private void Start(){
        objectPooler = objectPooler.Instance;
        spawnFreq = spawnFreqDesired;
    }

    // Update is called once per frame
    void Update()
    {       
        objectPooler.SpawnFromPool("EnemyBullet", transform.position, Quaternion.identity);
    }
}
