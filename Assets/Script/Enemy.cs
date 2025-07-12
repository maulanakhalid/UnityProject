using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // public float speed = 2f;
    public int health = 3;

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Bisa tambahkan efek animasi, suara, dll
        Destroy(gameObject);
    }

    void Update()
    {
        // Gerak maju ke kiri (atau ubah sesuai kebutuhan)
        // transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
}