using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed = 15.0f;
    public float padding = 1f;

    public float health = 250f;

    public float bulletSpeed = 5f;
    public float fireRate = 0.1f;

    public GameObject projectile;
    public GameObject leftFire;
    public GameObject rightFire;

    bool shootSequence;

    float xmin;
    float xmax;

    void Start()
    {
        // this is the distance between the player and the camera.
        float distance = transform.position.z - Camera.main.transform.position.z;

        // here we get the clamping.
        Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));

        xmin = leftmost.x + padding;
        xmax = rightmost.x - padding;
    }

    void Update () {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Debug.Log("Left Arrow Down");
            // We multiply by Time.deltaTime to ensure that speed is not related to framerate.
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        }

        else if (Input.GetKey(KeyCode.RightArrow))
        {
            Debug.Log("Right Arrow Down");
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        }

        // restrict player to the game space
        float newX = Mathf.Clamp(transform.position.x, xmin, xmax);
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space Key Pressed");
            InvokeRepeating("Fire", 0.0f, fireRate);
            print("Player shot fired");
        }
        
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Debug.Log("Space Key Released");
            CancelInvoke("Fire");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyProjectile")
        {
            float damageTaken = projectile.GetComponent<Projectile>().GetDamage();

            health -= damageTaken;
//            print("Damage Taken" + damageTaken);
            print("Health Remaining " + health);

            if (health < 0)
            {
                Destroy(gameObject);
            }
        }
    }

    void Fire ()
    {
        if (shootSequence) { 
            GameObject lasershot = Instantiate(projectile, leftFire.transform.position, Quaternion.identity) as GameObject;
            lasershot.GetComponent<Rigidbody2D>().velocity = new Vector3(0, bulletSpeed, 0);
            shootSequence = !shootSequence;
            Destroy(lasershot, 2);
        }

        else
        {
            GameObject lasershot = Instantiate(projectile, rightFire.transform.position, Quaternion.identity) as GameObject;
            lasershot.GetComponent<Rigidbody2D>().velocity = new Vector3(0, bulletSpeed, 0);
            shootSequence = !shootSequence;
            Destroy(lasershot, 2);
        }
    }

    void MoveWithKeys()
    {

    }
}
