using UnityEngine;

public class PlayerMoveScript : MonoBehaviour
{
    public MoveComponent moveComponent;

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

        moveComponent.Jump();
    }
}
