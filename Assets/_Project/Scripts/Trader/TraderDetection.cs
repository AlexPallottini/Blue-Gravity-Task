using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraderDetection : MonoBehaviour
{
    [SerializeField] private Trader trader;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            var inventory = other.GetComponent<PlayerInventory>();
            trader.ChangeTradingTextVisibility(true, inventory);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            trader.ChangeTradingTextVisibility(false, null);
        }
    }
}
