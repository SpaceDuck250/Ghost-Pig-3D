using UnityEngine;
using System;

public class PlayerMoveScript : MonoBehaviour
{
    public MoveComponent moveComponent;
    public IJump jumpComponent;

    public event System.Action OnJump;

    private void Update()
    {
        if (moveComponent == null)
        {
            return;
        }

        moveComponent.CheckInputs();
    }

    private void FixedUpdate()
    {
        if (moveComponent == null)
        {
            return;
        }

        moveComponent.Move();

        if (jumpComponent != null)
        {
            if (jumpComponent.Jump())
            {
                OnJump?.Invoke();
            }
        }
    }
}
