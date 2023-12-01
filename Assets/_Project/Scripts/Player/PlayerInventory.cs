using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private PlayerInventoryScreen inventoryScreen;

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
        inventoryScreen.Show();
    }
    private void CloseInventoryScreen()
    {
        inventoryScreen.Hide();
    }
}
