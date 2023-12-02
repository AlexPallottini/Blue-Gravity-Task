using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using System;

public class TraderScreenUI : MonoBehaviour
{
    public event Action<ItemSO> OnShopButtonClicked;

    [SerializeField] private CanvasGroup inventoryCG;
    [SerializeField] private TextMeshProUGUI playerGoldText;
    [SerializeField] private TraderScreenContainerUI traderScreenContainerUI;

    private Tween alphaTween;

    private void OnEnable()
    {
        traderScreenContainerUI.OnShopButtonClicked += ShopButtonClicked;
    }

    private void OnDisable()
    {
        traderScreenContainerUI.OnShopButtonClicked -= ShopButtonClicked;
        alphaTween?.Kill();
    }
    private void ShopButtonClicked(ItemSO item)
    {
        OnShopButtonClicked?.Invoke(item);
    }


    public void Show(List<ItemSO> itemsForSale, float playerMoney)
    {
        alphaTween?.Kill();
        alphaTween = inventoryCG.DOFade(1f, 0.25f);
        alphaTween.OnComplete(() =>
        {
            inventoryCG.interactable = true;
        });

        UpdateCatalog(itemsForSale, playerMoney);
    }

    public void Hide()
    {
        alphaTween?.Kill();
        alphaTween = inventoryCG.DOFade(0f, 0.25f);
        alphaTween.OnComplete(() =>
        {
            inventoryCG.interactable = false;
        });
    }

    public void UpdateCatalog(List<ItemSO> items, float playerMoney)
    {
        playerGoldText.SetText($"Player's Gold: {playerMoney}");
        traderScreenContainerUI.ShowItems(items);
    }
}
