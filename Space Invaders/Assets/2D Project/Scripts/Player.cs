using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform shootOffsetTransform;
    private float lives = 3f;
    private bool canMove = true;

    void Start()
    {
        // todo - get and cache animator
    }
    
    void Update()
    {
        if (canMove)
        {
            if (Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame)
            {
                GameObject shot = Instantiate(bulletPrefab, shootOffsetTransform.position, Quaternion.identity);
                // Debug.Log("Bang!");

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
                canMove = false;
            }
            
        }
    }
}
