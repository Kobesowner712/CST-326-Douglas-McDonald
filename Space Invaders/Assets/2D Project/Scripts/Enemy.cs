using System;
using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public delegate void EnemyDiedFunc(float points);

    public static event EnemyDiedFunc OnEnemyDied;

    private AudioSource sound;
    public String wallName = "";
    public AudioClip deathSFX;
    public AudioClip shotSFX;
    public GameObject sceneManager;


    private GameObject parent;
    
    public GameObject bulletPrefab;


    private void Start()
    {
        parent = transform.parent.gameObject;
        sound = gameObject.GetComponent<AudioSource>();

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Debug.Log("Ouch!");
        
        // todo - destroy the bullet
        if (collision.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        {
            if (collision.gameObject.CompareTag("Player Bullet"))
            {
                gameObject.GetComponent<Animator>().SetTrigger("EnemyDied");
                sound.PlayOneShot(deathSFX, 0.7f);
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                Destroy(collision.gameObject);
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
                parent.transform.parent.gameObject.GetComponent<AllRows>().decreaseEnemies();
                StartCoroutine(DestroyEnemy(collision));
            }
        }
    }

    IEnumerator DestroyEnemy(Collision2D collision)
    {
        yield return new WaitForSeconds(1.333f);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Wall"))
        {
            parent.GetComponent<EnemyRows>().hitAWall = true;
            wallName = other.name;
            parent.GetComponent<EnemyRows>().setWallName(wallName);
        }
    }

    public void shoot()
    {
        gameObject.GetComponent<Animator>().SetTrigger("EnemyShoot");
        GameObject shot = Instantiate(bulletPrefab, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 1f, 0f), Quaternion.identity);
        sound.PlayOneShot(shotSFX, 0.7f);
        
        
        // Debug.Log("Bang!");
        // todo - destroy the bullet after 3 seconds
        Destroy(shot, 3f);
    }

    
}
