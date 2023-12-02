using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Trader : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI tradingText;
    [SerializeField] private TraderInventory traderInventory;

    private PlayerInventory playerInventory;
    public void ChangeTradingTextVisibility(bool showing, PlayerInventory playerInventory)
    {
        tradingText.gameObject.SetActive(showing);
        this.playerInventory = playerInventory;
    }

    private void Update()
    {
        if (tradingText.isActiveAndEnabled && Input.GetKeyDown(KeyCode.Q))
        {
            if(PlayerActions.Instance.CurrentState == PlayerState.Walking)
            {
                BeginTrading();
            }
            else if (PlayerActions.Instance.CurrentState == PlayerState.Trading)
            {
                StopTrading();
            }
        }
    }

    public void BeginTrading()
    {
        PlayerActions.Instance.ChangeState(PlayerState.Trading);
        traderInventory.BeginTrading(playerInventory);
    }

    public void StopTrading()
    {
        PlayerActions.Instance.ChangeState(PlayerState.Walking);
        traderInventory.StopTrading();
    }
}
