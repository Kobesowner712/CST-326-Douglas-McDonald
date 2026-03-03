using System;
using System.Collections;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class StartScreen : MonoBehaviour
{
    public GameObject enemies;

    public GameObject player;
    public GameObject blackScreen;
    public TextMeshProUGUI info;
    public GameObject images;

    public GameObject barricades;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemies.SetActive(false);
        player.SetActive(false);
        player.SetActive(false);
        barricades.SetActive(false);
        blackScreen.SetActive(true);
        StartCoroutine(Wait());

    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.anyKey.wasPressedThisFrame)
        {
            startGame();
        }
        
    }


    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3);
        startGame();
    }

    void startGame()
    {
        enemies.SetActive(true);
        player.SetActive(true);
        player.SetActive(true);
        barricades.SetActive(true);
        blackScreen.SetActive(false);
        info.text = "";
        images.SetActive(false);
    }
}
