using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    void Shoot() {
        GameObject bullet = ObjectPool.SharedInstance.GetPooledObject();
        if(bullet != null){
            bullet.transform.position = transform.position;
            bullet.transform.rotation = transform.rotation;
            bullet.SetActive(true);
        }
    }
}
