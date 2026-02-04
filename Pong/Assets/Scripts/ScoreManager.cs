using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public GameObject winTextObject1;
    public GameObject winTextObject2;
    public GameObject ball;
    public float p1Score = 0;
    public float p2Score = 0;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        winTextObject1.SetActive(false);
        winTextObject2.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (p1Score == 11)
        {
            winTextObject1.SetActive(true);
            Debug.Log("Game Over, Left Paddle Wins");
            p1Score = 0;
            p2Score = 0;
            Destroy(ball);
            
        }
        else if (p2Score == 11)
        {
            winTextObject2.SetActive(true);
            Debug.Log("Game Over, Right Paddle Wins");
            p1Score = 0;
            p2Score = 0;
            Destroy(ball);
        }
        
    }
}
