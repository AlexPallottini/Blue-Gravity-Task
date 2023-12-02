using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PartShopButtonUI : MonoBehaviour
{
    public event Action<ItemSO> OnButtonClicked;
    [SerializeField] private Image itemImage;
    [SerializeField] private TextMeshProUGUI partPriceText;

    private ItemSO data;

    public void Init(ItemSO data)
    {
        this.data = data;
        itemImage.sprite = data.sprite;
        partPriceText.SetText($"${data.Value}");
    }

    public void Clicked()
    {
        OnButtonClicked?.Invoke(data);
    }
}
