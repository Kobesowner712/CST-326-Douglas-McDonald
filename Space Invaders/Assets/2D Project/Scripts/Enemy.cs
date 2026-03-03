using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public delegate void EnemyDiedFunc(float points);

    public static event EnemyDiedFunc OnEnemyDied;

    private AudioSource audioSource;
    public AudioClip tic;
    public AudioClip tac;

    private GameObject parent;
    
    public GameObject bulletPrefab;


    private void Start()
    {
        parent = transform.parent.gameObject;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Debug.Log("Ouch!");
        
        // todo - destroy the bullet
        if (collision.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        {
            if (collision.gameObject.CompareTag("Player Bullet"))
            {
                Destroy(collision.gameObject);
                Destroy(gameObject);
                if (gameObject.CompareTag("Bottom Row Enemies"))
                {
                    OnEnemyDied?.Invoke(10);
                }
                else if (gameObject.CompareTag("Middle Row Enemies"))
                {
                    OnEnemyDied?.Invoke(20);
                    
                }
                else if (gameObject.CompareTag("Side Enemies"))
                {
                    OnEnemyDied?.Invoke(15);
                }
                else
                {
                    OnEnemyDied?.Invoke(40);
                    
                }
                parent.transform.parent.gameObject.GetComponent<AllRows>().anEnemyDied = true;
            }
        }
        
        

        // todo - trigger death animation
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Wall"))
        {
            parent.GetComponent<EnemyRows>().hitAWall = true;
        }
    }

    public void shoot()
    {
        GameObject shot = Instantiate(bulletPrefab, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 1f, 0f), Quaternion.identity);
        
        // Debug.Log("Bang!");
        // todo - destroy the bullet after 3 seconds
        Destroy(shot, 3f);
    }


    // public void PlayTicSound()
    // {
    //     GetComponent<AudioSource>().PlayOneShot(tic);
    // }
    //
    // public void PlayTacSound()
    // {
    //     GetComponent<AudioSource>().PlayOneShot(tac);
    // }
}
