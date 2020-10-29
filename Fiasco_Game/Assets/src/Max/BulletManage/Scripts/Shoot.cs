using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    //Bullets to fire at once
    [SerializeField]
    private int bulletsAmount = 10;

    //[SerializeField]
    //private float shootFreq = 2f; 

    //Spread of the bullets to be fired
    [SerializeField]
    private float startAngle = 90f, endAngle = 270f;

    private Vector2 bulletMoveDirection;

    // Start is called before the first frame update
    void Start()
    {
        //Fire bullets every two seconds beginning at 0
        InvokeRepeating("Fire", 0f, 2f);
    }

    private void Fire(){
        float angleStep = (endAngle - startAngle) / bulletsAmount;
        float angle = startAngle;

        for (int i = 0; i < bulletsAmount; i++){
            float bulDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
            float bulDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);

            Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
            Vector2 bulDir = (bulMoveVector - transform.position).normalized;

            GameObject bul = BulletPool.bulletPoolInstance.GetBullet();
                bul.transform.position = transform.position;
                bul.transform.rotation = transform.rotation;
                bul.SetActive(true);
                bul.GetComponent<BulletUpdated>().SetMoveDirection(bulDir);

            angle += angleStep;
        }
    }
}
