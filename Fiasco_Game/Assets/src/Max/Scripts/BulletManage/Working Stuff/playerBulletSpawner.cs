using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerBulletSpawner : MonoBehaviour
{
    
    objectPooler objectPooler;

    void Start()
    {
        objectPooler = objectPooler.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")){
            objectPooler.SpawnFromPool("PlayerBullet", transform.position, Quaternion.identity);
            FindObjectOfType<AudioManager>().Play("PlayerShoot"); // - Greyson
        }
    }
}
