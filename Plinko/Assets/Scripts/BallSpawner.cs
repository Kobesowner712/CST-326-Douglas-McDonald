using UnityEngine;
using UnityEngine.InputSystem;

public class BallSpawner : MonoBehaviour
{

    public GameObject ballPrefab;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Instantiate(ballPrefab);

    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.spaceKey.isPressed)
        {
            Transform myTransform = GetComponent<Transform>();
            float position = Random.Range(0.0f, 2.0f);
            myTransform.position = new Vector3(position, 0.5f, 0f);
            Instantiate(ballPrefab, myTransform.position, Quaternion.identity);
        }
        
    }
}
