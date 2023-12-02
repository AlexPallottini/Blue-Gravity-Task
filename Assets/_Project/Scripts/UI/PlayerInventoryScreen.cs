
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class PlayerInventoryScreen : MonoBehaviour
{
    public event Action<Sprite, ItemType> OnOutfitChangedSelected;

    [SerializeField] private CanvasGroup inventoryCG;

    [SerializeField] private PartsListUI hoodPartsList;
    [SerializeField] private PartsListUI facePartsList;
    [SerializeField] private PartsListUI torsoPartsList;



    private Tween alphaTween;

    public bool IsActive { get; private set; } = false;
    private void OnEnable()
    {
        hoodPartsList.OnOutfitChangedSelected += OutfitButtonClicked;
        facePartsList.OnOutfitChangedSelected += OutfitButtonClicked;
        torsoPartsList.OnOutfitChangedSelected += OutfitButtonClicked;
    }

    private void OutfitButtonClicked(Sprite sprite, ItemType type)
    {
        OnOutfitChangedSelected?.Invoke(sprite, type);
    }

    private void OnDisable()
    {
        alphaTween?.Kill();

        hoodPartsList.OnOutfitChangedSelected -= OutfitButtonClicked;
        facePartsList.OnOutfitChangedSelected -= OutfitButtonClicked;
        torsoPartsList.OnOutfitChangedSelected -= OutfitButtonClicked;
    }

    public void Show(List<ItemSO> availableItems)
    {
        ClearLists();

        foreach (var item in availableItems)
        {
            var list = item.type switch
            {
                ItemType.Hood => hoodPartsList,
                ItemType.Face => facePartsList,
                ItemType.Torso => torsoPartsList,
                ItemType.None => null,
                _ => null
            };

            if (list != null)
            {
                list.AddPartToList(item);
            }
        }

        alphaTween?.Kill();
        alphaTween = inventoryCG.DOFade(1f, 0.25f);
        alphaTween.OnComplete(() =>
        {
            inventoryCG.interactable = true;
            IsActive = true;
        });
    }

    public void Hide()
    {
        ClearLists();

        alphaTween?.Kill();
        alphaTween = inventoryCG.DOFade(0f, 0.25f);
        alphaTween.OnComplete(() =>
        {
            inventoryCG.interactable = false;
            IsActive = false;
        });
    }

    private void ClearLists()
    {
        hoodPartsList.Clear();
        facePartsList.Clear();
        torsoPartsList.Clear();
    }
}
