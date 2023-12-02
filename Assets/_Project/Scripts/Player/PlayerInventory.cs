using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private PlayerInventoryScreen inventoryScreen;
    [SerializeField] private List<ItemSO> availableItems;
    [SerializeField] private PlayerSkinCustomization customization;
    [SerializeField] private CinemachineVirtualCamera inventoryCamera;

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
            if(PlayerActions.Instance.CurrentState == PlayerState.Walking)
            {
                OpenInventoryScreen();
            }
            else if (PlayerActions.Instance.CurrentState == PlayerState.Inventory)
            {
                CloseInventoryScreen();
            }
        }
    }
    private void OpenInventoryScreen()
    {
        PlayerActions.Instance.ChangeState(PlayerState.Inventory);
        inventoryCamera.gameObject.SetActive(true);
        inventoryScreen.Show(availableItems);
    }
    private void CloseInventoryScreen()
    {
        PlayerActions.Instance.ChangeState(PlayerState.Walking);
        inventoryCamera.gameObject.SetActive(false);
        inventoryScreen.Hide();
    }

    public void AddItemToInventory(ItemSO item)
    {
        if(!availableItems.Contains(item))
        {
            availableItems.Add(item);
        }
    }

    public void RemoveMoney(int amount)
    {
        CurrentMoney -= amount;
    }
}
