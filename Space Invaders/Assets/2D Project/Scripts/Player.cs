using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform shootOffsetTransform;
    private float lives = 3f;
    private bool canMove = true;
    public AudioClip shotSFX;
    public AudioClip deathSFX;
    private AudioSource sound;
    public GameObject sceneManager;
    void Start()
    {
        // todo - get and cache animator
        sound = gameObject.GetComponent<AudioSource>();
    }
    
    void Update()
    {
        if (canMove)
        {
            if (Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame)
            {
                GameObject shot = Instantiate(bulletPrefab, shootOffsetTransform.position, Quaternion.identity);
                // Debug.Log("Bang!");
                sound.PlayOneShot(shotSFX, 0.7f);

                // todo - destroy the bullet after 3 seconds
                Destroy(shot, 3f);
                // todo - trigger shoot animation
                GetComponent<Animator>().SetTrigger("Shot Trigger");
            }

            if (Keyboard.current != null && Keyboard.current.dKey.isPressed)
            {
                Vector3 newPosition = transform.position + new Vector3(6f, 0f, 0f) * Time.deltaTime;
                newPosition.x = Mathf.Clamp(newPosition.x, -7.76f, 7.76f);
                transform.position = newPosition;
            }

            if (Keyboard.current != null && Keyboard.current.aKey.isPressed)
            {
                Vector3 newPosition = transform.position - new Vector3(6f, 0f, 0f) * Time.deltaTime;
                newPosition.x = Mathf.Clamp(newPosition.x, -7.76f, 7.76f);
                transform.position = newPosition;
            }
        }
    }

    IEnumerator transferToCredits()
    {
        yield return new WaitForSeconds(3);
        sceneManager.GetComponent<GameToCredits>().LoadGame();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy Bullet"))
        {
            Destroy(other.gameObject);
            if (lives > 0)
            {
                lives -= 1;
            }
            Debug.Log("You Were Shot. Lives: " + lives);
            if (lives == 0)
            {
                Debug.Log("GAME OVER YOU LOSE!");
                sound.PlayOneShot(deathSFX);
                canMove = false;
                GetComponent<Animator>().SetTrigger("PlayerDeath");
                StartCoroutine(transferToCredits());

            }
            
        }
    }
}
