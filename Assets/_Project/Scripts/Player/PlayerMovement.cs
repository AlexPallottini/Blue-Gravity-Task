using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(PlayerAnimations))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement variables")]
    [Space]
    [SerializeField, Tooltip("Movement speed of the player"), Range(0.01f, 20f)] private float movementSpeed = 2f;

    private Rigidbody2D rb;
    private PlayerAnimations anim;

    private Vector2 movementDirection;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<PlayerAnimations>();
    }

    private void Start()
    {
        PlayerActions.Instance.ChangeState(PlayerState.Walking);
    }

    private void Update()
    {
        if(PlayerActions.Instance.CurrentState == PlayerState.Walking)
        {
            movementDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        }
        else
        {
            movementDirection = Vector2.zero;
        }

        anim.UpdateWalking(movementDirection);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movementDirection * movementSpeed * Time.fixedDeltaTime);
    }
}
