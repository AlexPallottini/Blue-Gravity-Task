using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Trader : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI tradingText;

    public void ChangeTradingTextVisibility(bool showing)
    {
        tradingText.gameObject.SetActive(showing);
    }

    private void Update()
    {
        if (tradingText.isActiveAndEnabled && Input.GetKeyDown(KeyCode.E))
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
        Debug.Log("Started trading");
    }

    public void StopTrading()
    {
        Debug.Log("Stopped trading");

    }
}
