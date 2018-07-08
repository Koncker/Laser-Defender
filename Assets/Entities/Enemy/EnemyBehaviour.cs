using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{

    public float myHealth = 250f;
    public GameObject projectile;

    public float bulletSpeed = 5.0f;
    public float fireRate = 0.1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerProjectile")
        {
            float damageTaken = projectile.GetComponent<Projectile>().GetDamage();

            myHealth -= damageTaken;
            print("Damage Taken" + damageTaken);
            print("Health Remaining" + myHealth);

            if (myHealth < 0)
            {
                Destroy(gameObject);
            }
        }
    }

    void Update()
    {
        float probabilityFire = Time.deltaTime * fireRate;
        if (Random.value < probabilityFire) {
            Fire();
        }
    }

    void Fire()
    {
        GameObject lasershot = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
        lasershot.GetComponent<Rigidbody2D>().velocity = new Vector3(0, -bulletSpeed, 0);
        Destroy(lasershot, 2);
    }
}
