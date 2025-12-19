using UnityEngine;

public class PlayerMoveScript : MonoBehaviour
{
    public MoveComponent moveComponent;
    public IJump jumpComponent;

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
            jumpComponent.Jump();
        }
    }
}
