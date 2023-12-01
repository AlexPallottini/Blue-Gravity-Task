
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerInventoryScreen : MonoBehaviour
{
    [SerializeField] private CanvasGroup inventoryCG;

    private Tween alphaTween;

    public bool IsActive { get; private set; } = false;

    private void OnDisable()
    {
        alphaTween?.Kill();
    }

    public void Show()
    {
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
        alphaTween?.Kill();
        alphaTween = inventoryCG.DOFade(0f, 0.25f);
        alphaTween.OnComplete(() =>
        {
            inventoryCG.interactable = false;
            IsActive = false;
        });
    }
}
