using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using TMPro;
using Unity.VisualScripting;


public class JumpCollissions : MonoBehaviour
{
    public GameObject DemoLogic;
    private MonoBehaviour logic;
    private float coins = 0;
    public TextMeshProUGUI coinUnit;

    private float score;
    public TextMeshProUGUI scoreText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = DemoLogic.GetComponent<ClickingLogic>();
        score = 0;

    }

    // Update is called once per frame
    void Update()
    {

        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Brick"))
        {
            Destroy(other.gameObject);
            score += 100;
            scoreText.text = "Mario\n" + score.ToString("000000");
        }
        else if (other.gameObject.CompareTag("Question Box"))
        {
            score += 100;
            scoreText.text = "Mario\n" + score.ToString("000000");
            updateCoins();
            
        }
    }
    
    
    public void updateCoins()
    {
        coins++;
        if (coins < 10)
        {
            coinUnit.text = "x0" + coins;
        }
        else
        {
            coinUnit.text = "x" + coins;
        }
    }
}
