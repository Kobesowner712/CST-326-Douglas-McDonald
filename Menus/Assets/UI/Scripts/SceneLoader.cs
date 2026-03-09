using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using Unity.VisualScripting;

public class SceneLoader : MonoBehaviour
{
    public void LoadGame()
    {
        StartCoroutine(_LoadGame());
        // Debug.Log("The scene has been loaded.");
        // SceneManager.LoadScene("New Scene");
        IEnumerator _LoadGame()
        {
            AsyncOperation loadOperation = SceneManager.LoadSceneAsync("New Scene");
            while (!loadOperation!.isDone) yield return null;
            GameObject capsuleObj = GameObject.Find("Capsule");
            Debug.Log(capsuleObj.name);
        }
        
    }
}
