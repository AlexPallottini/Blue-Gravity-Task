using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartSelectButtonUI : MonoBehaviour
{
    public event Action<Sprite, ItemType> OnClicked;

    [SerializeField] private Image buttonImage;

    private Sprite partSprite;
    private ItemType partType;

    public void Init(Sprite sprite, ItemType type)
    {
        partSprite = sprite;
        partType = type;
        buttonImage.sprite = partSprite;
    }

    public void Clicked()
    {
        OnClicked?.Invoke(partSprite, partType);
    }
}
