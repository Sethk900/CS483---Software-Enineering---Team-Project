using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class semicircleAttack : MonoBehaviour
{
    objectPooler objectPooler;
    public float spawnDelay = 1f;
    public float spawnFreq = 3f;
    private float shootCounter;

    // Start is called before the first frame update
    void Start()
    {
        objectPooler = objectPooler.Instance;
        shootCounter = spawnDelay;
    }

    // Update is called once per frame
    void Update()
    {
        if (shootCounter > 0){
            shootCounter -= Time.deltaTime;
        }else{
            for (int i = 0; i < 11; i++){
                objectPooler.SpawnFromPool("coconut", transform.position, Quaternion.identity);
            }
            shootCounter = spawnFreq;
        }
    }
}
