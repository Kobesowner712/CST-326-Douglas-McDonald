using UnityEngine;

public class DestroyBall : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<Transform>().position.y < -3)
        {
            Destroy(gameObject);
        }
        
    }
}
