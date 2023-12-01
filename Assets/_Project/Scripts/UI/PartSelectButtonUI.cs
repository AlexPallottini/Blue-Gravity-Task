using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartSelectButtonUI : MonoBehaviour
{
    [SerializeField] private Image buttonImage;
    public void Init(Sprite sprite)
    {
        buttonImage.sprite = sprite;
    }
}
