using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSkinCustomization : MonoBehaviour
{
    [SerializeField] private SpriteRenderer playerHood;
    [SerializeField] private SpriteRenderer playerFace;
    [SerializeField] private SpriteRenderer playerTorso;

    public void UpdatePlayerSkinPart(Sprite sprite, ItemType type)
    {
        switch (type) 
        {
            case ItemType.Hood:
                UpdatePlayerHood(sprite);
                break;
            case ItemType.Face:
                UpdatePlayerFace(sprite);
                break;
            case ItemType.Torso:
                UpdatePlayerTorso(sprite);
                break;
            default:
                Debug.LogError("Incorrect or invalid item type");
                break;
        }
    }

    private void UpdatePlayerHood(Sprite sprite)
    {
        playerHood.sprite = sprite;
    }
    
    private void UpdatePlayerFace(Sprite sprite) 
    {
        playerFace.sprite = sprite;
    }

    private void UpdatePlayerTorso(Sprite sprite)
    {
        playerTorso.sprite = sprite;
    }
}
