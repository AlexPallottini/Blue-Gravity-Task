using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableItemTest : MonoBehaviour
{
    [SerializeField] private ItemSO data;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            var player = other.GetComponent<PlayerInventory>();
            player.AddItemToInventory(data);
            Destroy(this.gameObject);
        }
    }
}
