using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float damage = 100f;
    public GameObject Enemy;
    public GameObject Player;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Collided");
        if (gameObject.tag == "PlayerProjectile" && collider.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
        }
        else if (gameObject.tag == "EnemyProjectile" && collider.gameObject.tag == "Player")
        {
            Debug.Log("Collided with player");
            Destroy(this.gameObject);

        }
    }

    public float GetDamage()
    {
        return damage;
    }

    void Hit()
    {

    }
}
