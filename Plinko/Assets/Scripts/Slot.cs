using System;
using UnityEngine;

public class Slot : MonoBehaviour
{
    public int slotNumber;
    void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Slot Number {slotNumber} Collied With {other.gameObject.name}");
    }
}
