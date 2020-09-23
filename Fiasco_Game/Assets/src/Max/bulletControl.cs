using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletControl : MonoBehaviour
{	
	public void Shoot(Vector2 origin, Vector2 shootingDirection, float bulletSpeed, GameObject bulletPrefab) {
		shootingDirection.Normalize();
		GameObject bullet = Instantiate(bulletPrefab, origin + shootingDirection.normalized, Quaternion.identity);
		bullet.GetComponent<Rigidbody2D>().velocity = shootingDirection * bulletSpeed;
		bullet.transform.Rotate(0, 0, Mathf.Atan2(shootingDirection.y, shootingDirection.x) * Mathf.Rad2Deg + 90);
	}
}
