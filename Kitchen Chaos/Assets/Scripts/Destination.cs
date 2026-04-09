using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Destination : MonoBehaviour
{

    [SerializeField] private Transform transform;

    private float minX = -4.6f;
    private float minZ = -4.16f;
    private float maxX = 6.16f;
    private float maxZ = 2.15f;
    private bool canSend = false;
    

    private void Start()
    {
            StartCoroutine(ChangeDestination());
    }

    IEnumerator ChangeDestination()
    {
        yield return new WaitForSeconds(4);
        float x = Random.Range(minX, maxX);
        float z = Random.Range(minZ, maxZ);
        transform.position = new Vector3(x, transform.position.y, z);
        canSend = true;
    }



    private void Update()
    {
        if (canSend)
        {
            StartCoroutine(ChangeDestination());
        }
        canSend = false;
    }
}
