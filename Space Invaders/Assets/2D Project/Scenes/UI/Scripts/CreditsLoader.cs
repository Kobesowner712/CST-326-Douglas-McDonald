using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;
// using Unity.VisualScripting;

public class CreditsLoader : MonoBehaviour
{
    public Button myButton;

    private void Start()
    {
        myButton.onClick.AddListener(LoadGame);
    }
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