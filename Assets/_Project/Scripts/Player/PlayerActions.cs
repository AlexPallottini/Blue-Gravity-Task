using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    None = 0,
    Walking = 1,
    Inventory = 2,
    Trading = 3,
}
public class PlayerActions : MonoBehaviour
{
    private static PlayerActions _instance;
    public static PlayerActions Instance => _instance ??= new GameObject("PlayerActions").AddComponent<PlayerActions>();

    [field:SerializeField] public PlayerState CurrentState { get; private set; }

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(Instance.gameObject);
            return;
        }
        else
        {
            _instance = this;
        }

        CurrentState = PlayerState.None;
    }

    public void ChangeState(PlayerState state)
    {
        if (state != PlayerState.None)
            CurrentState = state;
    }
}
