using UnityEngine;
using TMPro;
using System.Collections;

public class BallScript : MonoBehaviour
{
    private Rigidbody rb;

    public float speed = 100f;

    private float x = 0f;

    private float y = -5f;

    private float z = 0f;

    private float angle = 60f;
    
    public TextMeshProUGUI p1;
    public TextMeshProUGUI p2;

    
    public GameObject sm;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Vector3 movement = new Vector3(x, y, z);
        rb.AddForce(movement * speed);

    }

    private void OnCollisionEnter (Collision collision)
    {
        if (collision.gameObject.CompareTag("Paddle"))
        {
            // Debug.Log("Paddle Z: " + collision.gameObject.transform.position.z);
            // Debug.Log("Our Z: " + gameObject.transform.position.z);
            rb.linearVelocity = Vector3.zero;
            speed += 25;
            y = -y;
            z = gameObject.transform.position.z - collision.gameObject.transform.position.z;
            // Debug.Log(z);
            double temp = z / 2.5;
            z = (float)temp * angle;
            Vector3 movement = new Vector3(x, y, z);
            //Mathf.Min((y + z), (y + 3))
            rb.AddForce(movement * speed);
            collision.gameObject.GetComponent<DemoPaddle>().frameCount = 0;
        }

        if (collision.gameObject.CompareTag("Bottom Wall"))
        {
            Vector3 movement = new Vector3(x, y, -5);
            rb.AddForce(movement * speed);
        }
        if (collision.gameObject.CompareTag("Top Wall"))
        {
            Vector3 movement = new Vector3(x, y, 5);
            rb.AddForce(movement * speed);
        
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player 1 Goal"))
        {
            sm.GetComponent<ScoreManager>().p1Score += 1;
            p1.text = "Player 1 Score: " + sm.gameObject.GetComponent<ScoreManager>().p1Score;
            Debug.Log("Player 1 Scored");
            Debug.Log("Score: Player 1: " + sm.GetComponent<ScoreManager>().p1Score + ", Player 2: " + sm.GetComponent<ScoreManager>().p2Score);
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            StartCoroutine(wait());
            rb.linearVelocity = Vector3.zero;
            gameObject.GetComponent<Transform>().position = new Vector3(0, 5, 0);
            x = 0;
            y = -5;
            z = 0;
            speed = 100f;
            gameObject.GetComponent<MeshRenderer>().enabled = true;
            Vector3 movement = new Vector3(x, y, z);
            rb.AddForce(movement * speed);

        }
        else if (other.gameObject.CompareTag("Player 2 Goal"))
        {
            sm.GetComponent<ScoreManager>().p2Score += 1;
            p2.text = "Player 2 Score: " + sm.gameObject.GetComponent<ScoreManager>().p2Score;
            Debug.Log("Player 2 Scored");
            Debug.Log("Score: Player 1: " + sm.GetComponent<ScoreManager>().p1Score + ", Player 2: " + sm.GetComponent<ScoreManager>().p2Score);
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            StartCoroutine(wait());
            rb.linearVelocity = Vector3.zero;
            gameObject.GetComponent<Transform>().position = new Vector3(0, 25, 0);
            x = 0;
            y = 5;
            z = 0;
            speed = 100f;
            gameObject.GetComponent<MeshRenderer>().enabled = true;
            Vector3 movement = new Vector3(x, y, z);
            rb.AddForce(movement * speed);
            
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
