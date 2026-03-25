using System;
using System.Collections.Generic;
using UnityEngine;

public class PlateKitchenObject : KitchenObject
{

    public event EventHandler<OnIngredientAddedEventArgs> OnIngredientAdded;

    public class OnIngredientAddedEventArgs : EventArgs
    {
        public KitchenObjectSO kitchenObjectSO;
    }

    [SerializeField] private List<KitchenObjectSO> validKitchenObjectSOList;
    
    private List<KitchenObjectSO> kitchenObjectSOList;

    private void Awake()
    {
        kitchenObjectSOList = new List<KitchenObjectSO>();
    }

    public bool TryAddIngredient(KitchenObjectSO kitchenObjectSo)
    {
        if (!validKitchenObjectSOList.Contains(kitchenObjectSo))
        {
            // Not A Valid Ingredient.
            return false;
        }
        if (kitchenObjectSOList.Contains(kitchenObjectSo))
        {
            return false;
        }
        else
        {
            kitchenObjectSOList.Add(kitchenObjectSo);
            
            OnIngredientAdded?.Invoke(this, new OnIngredientAddedEventArgs
            {
                kitchenObjectSO = kitchenObjectSo
            });
            return true;
        }
    }

    public List<KitchenObjectSO> GetKitchenObjectSOList()
    {
        return kitchenObjectSOList;
    }
    
}
