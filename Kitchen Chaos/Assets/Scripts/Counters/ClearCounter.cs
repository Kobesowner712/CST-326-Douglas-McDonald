using System;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class ClearCounter : BaseCounter
{

  
    // [SerializeField] private ClearCounter secondClearCounter;
    // [SerializeField] private bool testing;
    
    [SerializeField] private KitchenObjectSO kitchenObjectSo;

    // private void Update()
    // {
    //     if (testing && Input.GetKeyDown(KeyCode.T))
    //     {
    //         if (kitchenObject != null)
    //         {
    //             kitchenObject.SetKitchenObjectParent(secondClearCounter);
    //         }
    //     }
    // }

    public override void Interact(Player player)
    {
        if (!HasKitchenObject())
        {
            // There isn't one.
            if (player.HasKitchenObject())
            {
                //Player is carrying something.
                player.GetKitchenObject().SetKitchenObjectParent(this);
            }
            else
            {
                //Player has nothing.
            }
        }
        else
        {
            // There is one.
            if (player.HasKitchenObject())
            {
                //player is carrying something
                if (player.GetKitchenObject().TryGetPlate(out PlateKitchenObject plateKitchenObject))
                {
                    // Player is holding a Plate
                    if (plateKitchenObject.TryAddIngredient(GetKitchenObject().GetKitchenObjectSO()))
                    {
                        GetKitchenObject().DestroySelf();
                    }
                }
                else
                {
                    // Player is not carrying a plate but something else
                    if (GetKitchenObject().TryGetPlate(out plateKitchenObject))
                    {
                        // Counter is holding a plate
                        if (plateKitchenObject.TryAddIngredient(player.GetKitchenObject().GetKitchenObjectSO()))
                        {
                            player.GetKitchenObject().DestroySelf();
                        }
                }
                }
            }

            else
            {
                // Player isn't carrying anything
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
    }

}
