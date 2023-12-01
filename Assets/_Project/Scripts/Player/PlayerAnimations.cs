using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    [SerializeField] private Animator ac;
    private Transform _acTransform;

    private void Start()
    {
        _acTransform = ac.GetComponent<Transform>();
    }

    public void UpdateWalking(Vector2 movement)
    {
        CheckForFlip(movement.x);
        bool isMoving = movement.x != 0 || movement.y != 0;
        ac.SetBool("isMoving", isMoving);
    }

    private void CheckForFlip(float xDirection)
    {
        Vector3 newLocalScale = _acTransform.localScale;

        if(xDirection > 0)
        {
            newLocalScale.x = Mathf.Abs(newLocalScale.x);
        }
        else if (xDirection < 0)
        {
            newLocalScale.x = -Mathf.Abs(newLocalScale.x);
        }
        _acTransform.localScale = newLocalScale;
    }
}
