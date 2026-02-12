using UnityEngine;
using TMPro;
using System.Collections;

public class BallScript : MonoBehaviour
{
    private Rigidbody rb;
    private AudioSource audioSource;
    public AudioClip audioClip;
    public AudioClip audioClip2;
    public AudioClip audioClip3;

    
    public float speed = 0.1f;

    private float x = 0f;

    private float y = -5f;

    private float z = 0f;
    
    public TextMeshProUGUI p1;
    public TextMeshProUGUI p2;

    
    public GameObject sm;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Vector3 movement = new Vector3(x, y, z);
        rb.linearVelocity = movement * speed;

    }

    private void OnCollisionEnter (Collision collision)
    {
        if (collision.gameObject.CompareTag("Paddle"))
        {
            audioSource = gameObject.GetComponent<AudioSource>();
            // Debug.Log("Paddle Z: " + collision.gameObject.transform.position.z);
            // Debug.Log("Our Z: " + gameObject.transform.position.z);
            // rb.linearVelocity = Vector3.zero;
            speed += 1f;
            
            y = -y;
            z = gameObject.transform.position.z - collision.gameObject.transform.position.z;
            // Debug.Log(z);
            double temp = z / 2.5;
            Debug.Log(temp);
            z = (float)temp *(y);
            if (z < 0 && z > -1)
            {
                z--;
            } else if (z > 0 && z < 1)
            {
                z++;
            }
            // Debug.Log(z);
            Vector3 movement = new Vector3(x, y, z / 2);
            //Mathf.Min((y + z), (y + 3))
            rb.linearVelocity = movement * speed;
            if (temp >= -0.25 && temp <= 0.25)
            {
                audioSource.PlayOneShot(audioClip);
            } else if ((temp <= 0.75 && temp > 0.25) || (temp >= -0.75 && temp < -0.25))
            {
                audioSource.PlayOneShot(audioClip2);
            }
            else
            {
                audioSource.PlayOneShot(audioClip3);
            }
            
            collision.gameObject.GetComponent<DemoPaddle>().frameCount = 0;
        }

        if (collision.gameObject.CompareTag("Bottom Wall"))
        {
            Vector3 movement = new Vector3(x, y, -5);
            audioSource.PlayOneShot(audioClip2);
            rb.linearVelocity = movement * speed;
        }
        if (collision.gameObject.CompareTag("Top Wall"))
        {
            Vector3 movement = new Vector3(x, y, 5);
            audioSource.PlayOneShot(audioClip2);
            rb.linearVelocity = movement * speed;
        }


    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player 2 Goal"))
        {
            sm.GetComponent<ScoreManager>().p1Score += 1;
            p1.text = "Player 1 Score: " + sm.gameObject.GetComponent<ScoreManager>().p1Score;
            p1.color = new Color(0f, 255f, 0f);
            p2.color = new Color(255f, 255f, 255f);
            Debug.Log("Player 1 Scored");
            Debug.Log("Score: Player 1: " + sm.GetComponent<ScoreManager>().p1Score + ", Player 2: " + sm.GetComponent<ScoreManager>().p2Score);
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            StartCoroutine(wait());
            rb.linearVelocity = Vector3.zero;
            gameObject.GetComponent<Transform>().position = new Vector3(0, 25, 0);
            gameObject.GetComponent<Transform>().localScale = new Vector3(1, 1, 1);
            x = 0;
            y = 5;
            z = 0;
            speed = 2f;
            gameObject.GetComponent<MeshRenderer>().enabled = true;
            Vector3 movement = new Vector3(x, y, z);
            rb.linearVelocity = movement * speed;

        }
        else if (other.gameObject.CompareTag("Player 1 Goal"))
        {
            sm.GetComponent<ScoreManager>().p2Score += 1;
            p2.text = "Player 2 Score: " + sm.gameObject.GetComponent<ScoreManager>().p2Score;
            p2.color = new Color(0f, 255f, 0f);
            p1.color = new Color(255f, 255f, 255f);
            Debug.Log("Player 2 Scored");
            Debug.Log("Score: Player 1: " + sm.GetComponent<ScoreManager>().p1Score + ", Player 2: " + sm.GetComponent<ScoreManager>().p2Score);
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            StartCoroutine(wait());
            rb.linearVelocity = Vector3.zero;
            gameObject.GetComponent<Transform>().position = new Vector3(0, 5, 0);
            gameObject.GetComponent<Transform>().localScale = new Vector3(1, 1, 1);
            x = 0;
            y = -5;
            z = 0;
            speed = 2f;
            gameObject.GetComponent<MeshRenderer>().enabled = true;
            Vector3 movement = new Vector3(x, y, z);
            rb.linearVelocity = movement * speed;
            
        }
        else if (other.gameObject.CompareTag("Speed Up"))
        {
            Debug.Log("Speeding Up");
            speed += 2f;
            rb.linearVelocity = new Vector3(x, y, z / 2) * speed;

        }
        else if (other.gameObject.CompareTag("Big"))
        {
            Debug.Log("Increasing Size");
            gameObject.GetComponent<Transform>().localScale *= 2;
        }
        else if (other.gameObject.CompareTag("Small"))
        {
            Debug.Log("Decreasing Size");
            gameObject.GetComponent<Transform>().localScale *= 0.5f;
            
        }
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(3.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
