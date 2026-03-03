using System;
using System.IO;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    private float score = 0;
    private float highScore;
    void Start()
    {
       // todo - sign up for notification about enemy death 
       Enemy.OnEnemyDied += OnEnemyDied;
       String fileText = File.ReadAllText("C:/Users/dougi/CST 326 - Douglas McDonald/Space Invaders/Assets/2D Project/Scripts/highscore.txt");
       highScore = float.Parse(fileText);
       highScoreText.text = "High Score: " + highScore.ToString("0000");
    }

    void OnEnemyDied(float scoreEntry)
    {
        Debug.Log($"Killed Enemy Worth {scoreEntry}");
        score += scoreEntry;
        scoreText.text = "Score: " + score.ToString("0000");
        if (score > highScore)
        {
            highScore = score;
            File.WriteAllText("C:/Users/dougi/CST 326 - Douglas McDonald/Space Invaders/Assets/2D Project/Scripts/highscore.txt", highScore.ToString());
            highScoreText.text = "High Score: " + highScore.ToString("0000");
        }
        
        
    }
}
