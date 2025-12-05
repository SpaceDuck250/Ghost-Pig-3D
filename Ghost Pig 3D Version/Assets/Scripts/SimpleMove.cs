using UnityEngine;

public class SimpleObjectMove : MoveComponent 
{
    private float moveX;
    private float moveZ;

    private Vector3 refVelocity;

    public float moveSpeed;
    public float smoothValue;

    public override void EditMoveValues(TransformableData moveData)
    {
        moveSpeed = moveData.moveSpeed;
        smoothValue = moveData.smoothValue;
    }

    public override void CheckInputs()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        moveZ = Input.GetAxisRaw("Vertical");
    }

    public override void Move()
    {
        Vector3 targetVelocity = new Vector3(moveX, 0, moveZ) * moveSpeed;
        targetVelocity.y = rb.linearVelocity.y;

        rb.linearVelocity = Vector3.SmoothDamp(rb.linearVelocity, targetVelocity, ref refVelocity, smoothValue * Time.fixedDeltaTime);
    }
}
