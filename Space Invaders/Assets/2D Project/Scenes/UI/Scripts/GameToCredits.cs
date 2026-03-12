using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;
// using Unity.VisualScripting;

public class GameToCredits : MonoBehaviour
{
    public void LoadGame()
    {
        StartCoroutine(_LoadGame());
        // Debug.Log("The scene has been loaded.");
        // SceneManager.LoadScene("New Scene");
        IEnumerator _LoadGame()
        {
            AsyncOperation loadOperation = SceneManager.LoadSceneAsync("Credits");
            while (!loadOperation!.isDone) yield return null;
        }
        
    }
}