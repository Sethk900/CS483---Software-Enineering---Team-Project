using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerControl : MonoBehaviour
{

    public float moveSpeed = 5f;
    public float crosshairDistance = 2f;
    public int health = 100;
    public float bulletSpeed = 20.0f;
    float lastDamaged = 0;

    public Rigidbody2D rb;
    public GameObject bulletPrefab;
    public GameObject crosshair;
    public Camera mainCam;

    bulletControl bcInst;

    Vector2 movementDir;
    Vector2 lookDir;
    Vector2 mousePos;
    Quaternion _facing;

    bool playerContactWithEnemy;

    void Start()
    {
        bcInst = GetComponent<bulletControl>();
        Cursor.lockState = CursorLockMode.Confined;
        //Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        movementDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetButtonDown("Fire1"))
        {
            bcInst.Shoot(rb.position, crosshair.transform.localPosition, bulletSpeed, bulletPrefab);
            FindObjectOfType<AudioManager>().Play("PlayerShoot"); // - Greyson
        }
    }

    /* 
	 * Called 50 times a second rather than every frame.
	 * This makes physics more reliable as it isn't locked
	 * to the frame rate.
	 */
    void FixedUpdate()
    {
        // Position is updated here, using Time.fixedDeltaTime keeps movement consistent
        rb.MovePosition(rb.position + movementDir * moveSpeed * Time.fixedDeltaTime);

        // Shooting angle is updated here
        lookDir = mousePos - rb.position;
        Aim();
    }

    void Aim()
    {
        if (lookDir.magnitude > crosshairDistance)
        {
            mousePos = rb.position + lookDir.normalized * crosshairDistance;

        }
        crosshair.transform.position = mousePos;
    }

    // Handle collisions
    void OnCollisionStay2D(Collision2D col)
    {
        if (Time.time > lastDamaged + 0.5f)
        {
            if (col.gameObject.tag.Equals("worm"))
            {
                lastDamaged = Time.time;
                DamagePlayer(DifficultyImplementation.PlayerDamage);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("EnemyBullet"))
        {
			DamagePlayer(DifficultyImplementation.PlayerDamage);
            //DamagePlayer(10);
        }
    }

    // Handle Enemy taking damage
    public void DamagePlayer(int damage)
    {
        //FindObjectOfType<AudioManager>().Play("PlayerHurt"); // - Greyson
        if (health > 0) health -= damage;
        UIScript.health -= damage;
        if (UIScript.health <= 0)
        {
            PlayerDeath();
        }
    }

    // Function called on player death
    void PlayerDeath()
    {
        FindObjectOfType<AudioManager>().Play("PlayerDeath"); // - Greyson
        //Destroy(gameObject); // Comment out without adverse effects? This causes crashes at the death screen - Greyson
        SceneManager.LoadScene("DeathScreen");
        FindObjectOfType<AudioManager>().Play("PlayerDeath"); // - Greyson       
    }
}

public class HealthLogic : playerControl
{
    //public int health = 100;

    /*public void DamagePlayer(int damage) {
       health -= damage;
       UIScript.health -= damage;
       if (UIScript.health <= 0) {

       }
   }*/
}