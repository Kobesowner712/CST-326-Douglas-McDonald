using UnityEngine;
using System;
using System.Collections;

public class AllRows : MonoBehaviour
{
    public bool moveDown = false;
    private GameObject row1;
    private GameObject row2;
    private GameObject row3;
    private String wallName;
    private int enemies = 18;
    public GameObject sceneManager;
    
    public bool anEnemyDied = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        row1 = gameObject.transform.Find("Enemy Row 1").gameObject;
        row2 = gameObject.transform.Find("Enemy Row 2").gameObject;
        row3 = gameObject.transform.Find("Enemy Row 3").gameObject;
    }
    
    IEnumerator transferToCredits()
    {
        yield return new WaitForSeconds(3);
        sceneManager.GetComponent<GameToCredits>().LoadGame();
    }

    public void setWallName(String wallName)
    {
        this.wallName = wallName;
    }

    public void decreaseEnemies()
    {
        enemies--;
        if (enemies <= 0)
        {
            StartCoroutine(transferToCredits());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (moveDown)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x,
                gameObject.transform.position.y - 0.3f, gameObject.transform.position.z);
            moveDown = false;
            if (wallName.Equals("Left Wall"))
            {
                row1.GetComponent<EnemyRows>().movingLeft = false;
                row2.GetComponent<EnemyRows>().movingLeft = false;
                row3.GetComponent<EnemyRows>().movingLeft = false;
            }
            else
            {
                row1.GetComponent<EnemyRows>().movingLeft = true;
                row2.GetComponent<EnemyRows>().movingLeft = true;
                row3.GetComponent<EnemyRows>().movingLeft = true;
            }

        }


        if (anEnemyDied)
        {
            row1.GetComponent<EnemyRows>().lowerSpeed();
            row2.GetComponent<EnemyRows>().lowerSpeed();
            row3.GetComponent<EnemyRows>().lowerSpeed();
            anEnemyDied = false;

        }
        
    }
}
