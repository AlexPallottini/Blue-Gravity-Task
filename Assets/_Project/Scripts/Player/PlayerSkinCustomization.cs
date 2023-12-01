using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSkinCustomization : MonoBehaviour
{
    [SerializeField] private Image playerHood;
    [SerializeField] private Image playerFace;
    [SerializeField] private Image playerTorso;

    public void UpdatePlayerHood(Sprite sprite)
    {
        playerHood.sprite = sprite;
    }
    
    public void UpdatePlayerFace(Sprite sprite) 
    {
        playerFace.sprite = sprite;
    }

    public void UpdatePlayerTorso(Sprite sprite)
    {
        playerTorso.sprite = sprite;
    }
}
