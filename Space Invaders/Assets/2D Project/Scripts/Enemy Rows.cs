using UnityEngine;
using System.Collections;
using System;
using UnityEngine.Audio;

public class EnemyRows : MonoBehaviour
{

    private GameObject allRows;
    private GameObject[] enemies;


    private bool canMove = false;
    private bool canShoot = false;
    public bool movingLeft = true;
    public String wallName;
    public bool hitAWall = false;

    public float seconds = 1;
    
    void Start()
    {
        canMove = false;
        bool canShoot = false;
        allRows = transform.parent.gameObject;
        enemies = new GameObject[6];
        enemies[0] = gameObject.transform.Find("1").gameObject;
        enemies[1] = gameObject.transform.Find("2").gameObject;
        enemies[2] = gameObject.transform.Find("3").gameObject;
        enemies[3] = gameObject.transform.Find("4").gameObject;
        enemies[4] = gameObject.transform.Find("5").gameObject;
        enemies[5] = gameObject.transform.Find("6").gameObject;
        StartCoroutine(Move());
        Debug.Log(gameObject.name);
        StartCoroutine(Shoot());
    }


    IEnumerator Move()
    {
        yield return new WaitForSeconds(seconds);
        if (hitAWall)
        {
            allRows.GetComponent<AllRows>().moveDown = true;
            hitAWall = false;
        }


        if (movingLeft)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x - 0.25f,
                gameObject.transform.position.y, gameObject.transform.position.z);
        }
        else
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x + 0.25f,
                gameObject.transform.position.y, gameObject.transform.position.z);
        }

        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i] != null)
            {
                enemies[i].gameObject.GetComponent<Animator>().SetTrigger("Move");
            }
        }
        canMove = true;
    }

    IEnumerator Shoot()
    {
        float shootDelay = UnityEngine.Random.Range(0.0f, 10.0f);
        int shooter = UnityEngine.Random.Range(0, 6);
        yield return new WaitForSeconds(shootDelay);
        if (enemies[shooter] != null)
        {
            enemies[shooter].GetComponent<Enemy>().shoot();
            
        }

        canShoot = true;
    }

    public void setWallName(String wallName)
    {
        this.wallName = wallName;
        allRows.GetComponent<AllRows>().setWallName(wallName);

    }

    public void lowerSpeed()
    {
        seconds -= 0.05f;
    }

    void Update()
    {
        // Debug.Log(gameObject.name + " updated!");
        if (canMove)
        {
            StartCoroutine(Move());
        }
        canMove = false;

        if (canShoot)
        {
            StartCoroutine(Shoot());
        }

        canShoot = false;


    }
}
