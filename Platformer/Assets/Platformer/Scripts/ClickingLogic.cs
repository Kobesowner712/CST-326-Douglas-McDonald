using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using TMPro;
using Unity.VisualScripting;

public class ClickingLogic : MonoBehaviour
{
    private float coins = 0;
    public TextMeshProUGUI coinUnit;
    public Camera rayCamera;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Mouse.current.position.value;
        Ray screenRay = rayCamera.ScreenPointToRay(mousePosition);

        if (Physics.Raycast(screenRay, out RaycastHit screenHitInfo))
        {
            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                if (screenHitInfo.collider.CompareTag("Brick"))
                {
                    Destroy(screenHitInfo.collider.gameObject);
                }
                else if (screenHitInfo.collider.CompareTag("Question Box"))
                {
                    coins++;
                    if (coins < 10)
                    {
                        coinUnit.text = "x0" + coins;
                    }
                    else
                    {
                        coinUnit.text = "x" + coins;
                    }
                }
            }
        }

    }
}
