using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraderInventory : MonoBehaviour
{
    [SerializeField] private List<ItemSO> itemsForSale;
    [SerializeField] private TraderScreenUI traderScreenUI;
    private PlayerInventory playerInventory;

    private void OnEnable()
    {
        traderScreenUI.OnShopButtonClicked += PurchaseMade;
    }

    private void OnDisable()
    {
        traderScreenUI.OnShopButtonClicked += PurchaseMade;
    }

    public void RemoveItem(ItemSO item)
    {
        itemsForSale.Remove(item);
    }

    public void BeginTrading(PlayerInventory playerInventory)
    {
        this.playerInventory = playerInventory;
        traderScreenUI.Show(itemsForSale, playerInventory.CurrentMoney);
    }

    public void StopTrading()
    {
        playerInventory = null;
        traderScreenUI.Hide();
    }
    private void PurchaseMade(ItemSO item)
    {
        if (itemsForSale.Contains(item))
        {
            if(playerInventory.CurrentMoney < item.Value)
            {
                Debug.Log("Player doesn't have enough money for the purchase");
                return;
            }

            itemsForSale.Remove(item);
            playerInventory.AddItemToInventory(item);

            playerInventory.RemoveMoney(item.Value);

            traderScreenUI.UpdateCatalog(itemsForSale, playerInventory.CurrentMoney);
        }      
    }

}
