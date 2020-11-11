using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBulletSpawner : MonoBehaviour
{

    objectPooler objectPooler;

    private void Start(){
        objectPooler = objectPooler.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        objectPooler.SpawnFromPool("EnemyBullet", transform.position, Quaternion.identity);
    }
}
