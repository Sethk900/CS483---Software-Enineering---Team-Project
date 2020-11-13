using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion8 : MonoBehaviour, IpooledObject
{
    public void OnObjectSpawn(){       
        //just lower it a little bit so it looks better
        transform.position = new Vector2(transform.position.x, transform.position.y - 1f);
    }
}
