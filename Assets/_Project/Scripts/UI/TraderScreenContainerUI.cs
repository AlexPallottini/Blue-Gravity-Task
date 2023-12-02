using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TraderScreenContainerUI : MonoBehaviour
{
    public event Action<ItemSO> OnShopButtonClicked;
    [SerializeField] private PartShopButtonUI buttonPrefab;
    private List<PartShopButtonUI> showedItems = new();

    public void ShowItems(List<ItemSO> items)
    {
        ClearAllItems();
        foreach (var item in items)
        {
            var go = Instantiate(buttonPrefab, this.transform);
            go.Init(item);
            go.OnButtonClicked += ShopButtonClicked;
            showedItems.Add(go);
        }
    }

    private void ClearAllItems()
    {
        for (int i = 0; i < showedItems.Count; i++)
        {
            var item = showedItems[i];
            showedItems[i] = null;

            item.OnButtonClicked -= ShopButtonClicked;
            Destroy(item.gameObject);
        }
        showedItems = new();
    }

    private void ShopButtonClicked(ItemSO item)
    {
        OnShopButtonClicked?.Invoke(item);
    }
}
