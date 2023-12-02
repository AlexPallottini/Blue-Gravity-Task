using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private PlayerInventoryScreen inventoryScreen;
    [SerializeField] private List<ItemSO> availableItems;
    [SerializeField] private PlayerSkinCustomization customization;

    [field: SerializeField] public int CurrentMoney = 10;


    private void OnEnable()
    {
        inventoryScreen.OnOutfitChangedSelected += ChangeSkin;
    }

    private void OnDisable()
    {
        inventoryScreen.OnOutfitChangedSelected -= ChangeSkin;
    }

    private void ChangeSkin(Sprite sprite, ItemType type)
    {
        if(customization != null)
        {
            customization.UpdatePlayerSkinPart(sprite, type);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(!inventoryScreen.IsActive)
            {
                OpenInventoryScreen();
            }
            else
            {
                CloseInventoryScreen();
            }
        }
    }
    private void OpenInventoryScreen()
    {
        inventoryScreen.Show(availableItems);
    }
    private void CloseInventoryScreen()
    {
        inventoryScreen.Hide();
    }

    public void AddItemToInventory(ItemSO item)
    {
        if(!availableItems.Contains(item))
        {
            availableItems.Add(item);
        }
    }
}
