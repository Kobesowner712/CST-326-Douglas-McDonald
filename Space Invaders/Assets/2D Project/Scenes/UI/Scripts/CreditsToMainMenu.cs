using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;
// using Unity.VisualScripting;

public class CreditsToMainMenu : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(WaitFiveSeconds());
    }
    // public void LoadGame()
    // {
    //     StartCoroutine(_LoadGame());
    //     // Debug.Log("The scene has been loaded.");
    //     // SceneManager.LoadScene("New Scene");
    //     IEnumerator _LoadGame()
    //     {
    //         AsyncOperation loadOperation = SceneManager.LoadSceneAsync("Credits");
    //         while (!loadOperation!.isDone) yield return null;
    //     }
    // }


    IEnumerator WaitFiveSeconds()
    {
        yield return new WaitForSeconds(5);
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync("2D Project/Scenes/Main Menu");
        while (!loadOperation!.isDone) yield return null;
    }
}