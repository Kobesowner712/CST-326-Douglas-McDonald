using UnityEngine;

public class AllRows : MonoBehaviour
{
    public bool moveDown = false;
    private GameObject row1;
    private GameObject row2;
    private GameObject row3;
    
    public bool anEnemyDied = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        row1 = gameObject.transform.Find("Enemy Row 1").gameObject;
        row2 = gameObject.transform.Find("Enemy Row 2").gameObject;
        row3 = gameObject.transform.Find("Enemy Row 3").gameObject;

    }

    // Update is called once per frame
    void Update()
    {
        if (moveDown)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x,
                gameObject.transform.position.y - 0.3f, gameObject.transform.position.z);
            moveDown = false;
            row1.GetComponent<EnemyRows>().movingLeft = !row1.GetComponent<EnemyRows>().movingLeft;
            row2.GetComponent<EnemyRows>().movingLeft = !row2.GetComponent<EnemyRows>().movingLeft;
            row3.GetComponent<EnemyRows>().movingLeft = !row3.GetComponent<EnemyRows>().movingLeft;
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
