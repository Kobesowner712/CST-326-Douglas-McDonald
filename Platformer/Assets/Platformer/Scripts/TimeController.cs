using UnityEngine;
using TMPro;

public class TimeController : MonoBehaviour
{

    public TextMeshProUGUI timeText;
    float timeLeft = 100;
    public bool isCountingDown = true;
    public GameObject player;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timeLeft <= 0f)
        {
            Debug.Log("TIME IS UP, YOU LOSE!");
            isCountingDown = false;
        }

        if (isCountingDown)
        {
            timeLeft -= Time.deltaTime;
            timeText.text = $"TIME\n {((int)timeLeft).ToString()}";
        }


    }
}
