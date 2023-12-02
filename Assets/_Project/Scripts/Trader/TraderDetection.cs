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
            trader.ChangeTradingTextVisibility(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            trader.ChangeTradingTextVisibility(false);
        }
    }
}
