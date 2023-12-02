using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartsListUI : MonoBehaviour
{
    public event Action<Sprite, ItemType> OnOutfitChangedSelected;
    [SerializeField] private PartSelectButtonUI buttonPrefab;
    [SerializeField] private List<PartSelectButtonUI> availableItems;

    private void OnDisable()
    {
        Clear();
    }

    public void AddPartToList(ItemSO item)
    {
        var go = Instantiate(buttonPrefab, this.transform);
        go.Init(item.sprite, item.type);
        availableItems.Add(go);

        go.OnClicked += OutfitButtonClicked;
    }

    private void OutfitButtonClicked(Sprite sprite, ItemType type)
    {
        OnOutfitChangedSelected.Invoke(sprite, type);
    }

    public void Clear()
    {
        int count = availableItems.Count;
        for (int i = 0; i < count; i++)
        {
            var item = availableItems[i];
            availableItems[i] = null;

            item.OnClicked -= OutfitButtonClicked;
            Destroy(item.gameObject);
        }

        availableItems.RemoveAll(item => item == null);
    }
}
