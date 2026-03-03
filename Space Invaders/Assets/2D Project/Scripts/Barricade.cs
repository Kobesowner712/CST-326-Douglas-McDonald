using System;
using UnityEngine;

public class Barricade : MonoBehaviour
{

    private float health = 4f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy Bullet"))
        {
            Destroy(other.gameObject);
            health -= 1;
            gameObject.transform.localScale = new Vector3(health / 4f, health / 4f, health / 4f);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(other.gameObject);
        health -= 1;
        gameObject.transform.localScale = new Vector3(health / 4f, health / 4f, health / 4f);
    }
}
