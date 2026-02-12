using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class DemoPaddle : MonoBehaviour
{
    public float paddleSpeed = 1f;

    public float forceStrength = 10f;

    public float maxZ = 5f;

    public GameObject scores;

    public AudioClip sound;
    private AudioSource audioSource;

    private Rigidbody rb;
    private float movementX;
    private float movementY;
    private bool down;
    public bool canParry = true;
    private bool up;
    public GameObject ball;
    public int playerNumber = 1;



    public int frameCount = 0;

    void OnParry(InputValue value)
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        if (canParry)
        {

            if (value.isPressed)
            {

                // float temp =  gameObject.transform.position.y - ball.gameObject.transform.position.y;
                if (ball.gameObject.transform.position.y > 15)
                {
                    if (ball.gameObject.transform.position.y >= 29)
                    {
                        audioSource.PlayOneShot(sound);
                        ball.GetComponent<BallScript>().speed += 1;
                        Debug.Log("PARRIED");
                    }
                }
                else
                {
                    if (ball.gameObject.transform.position.y <= -1)
                    {
                        ball.GetComponent<BallScript>().speed += 2;
                        audioSource.PlayOneShot(sound);
                        Debug.Log("PARRIED");
                    }
                }
            }

        }
    }


    // void OnMoveUp(InputValue value)
    // {
    //     if (value.isPressed)
    //     {
    //         Vector3 newPosition = transform.position + new Vector3(0f, 0f, paddleSpeed) * Time.deltaTime;
    //         newPosition.z = Mathf.Clamp(newPosition.z, -12f, maxZ);
    //         transform.position = newPosition;
    //     }
    // }
    //
    // void OnMoveDown(InputValue value)
    // {
    //     if (value.isPressed)
    //     {
    //         Vector3 newPosition = transform.position - new Vector3(0f, 0f, paddleSpeed) * Time.deltaTime;
    //         newPosition.z = Mathf.Clamp(newPosition.z, -12f, maxZ);
    //         transform.position = newPosition;
    //     }
    // }
    // void Start()
    // {
    //     up = Keyboard.current.aKey.isPressed;
    //     down = Keyboard.current.dKey.isPressed;
    // }
    
    
    void Update()
    {
        if (playerNumber != 2)
        {

            if (Keyboard.current.sKey.isPressed)
            {
                Vector3 newPosition = transform.position + new Vector3(0f, 0f, paddleSpeed) * Time.deltaTime;
                newPosition.z = Mathf.Clamp(newPosition.z, -12f, maxZ);
                transform.position = newPosition;
            }

            if (Keyboard.current.wKey.isPressed)
            {
                Vector3 newPosition = transform.position - new Vector3(0f, 0f, paddleSpeed) * Time.deltaTime;
                newPosition.z = Mathf.Clamp(newPosition.z, -12f, maxZ);
                transform.position = newPosition;
            }
        }
        else
        {
            if (Keyboard.current.downArrowKey.isPressed)
            {
                Vector3 newPosition = transform.position + new Vector3(0f, 0f, paddleSpeed) * Time.deltaTime;
                newPosition.z = Mathf.Clamp(newPosition.z, -12f, maxZ);
                transform.position = newPosition;
            }

            if (Keyboard.current.upArrowKey.isPressed)
            {
                Vector3 newPosition = transform.position - new Vector3(0f, 0f, paddleSpeed) * Time.deltaTime;
                newPosition.z = Mathf.Clamp(newPosition.z, -12f, maxZ);
                transform.position = newPosition;
            }
        }

    }
}




// Vector3 up = Vector3.up;
// Quaternion testRotation = Quaternion.Euler(60f, 0f, 0f);
// Vector3 rotatedVector = testRotation * up;
// Quaternion otherRotation = Quaternion.Euler(-60f, 0f, 0f);
// Vector3 otherRotatedVector = otherRotation * up;
// Debug.DrawRay(transform.position, rotatedVector * 5f, Color.red);
// Debug.DrawRay(transform.position, otherRotatedVector * 5f, Color.blue);
