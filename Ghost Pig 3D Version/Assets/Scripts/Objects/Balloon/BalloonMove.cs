using UnityEngine;

public class BalloonMove : MoveComponent
{
    private float moveX;
    private float moveZ;

    private float moveSpeed;
    private float smoothValue;

    private Vector3 refVel;

    private Vector3 forward;
    private Vector3 sideways;


    public override void EditScriptUniqueDataValues(TransformableData data)
    {
        moveSpeed = data.moveSpeed;
        smoothValue = data.smoothValue;
    }

    public override void CheckInputs()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        moveZ = Input.GetAxisRaw("Vertical");

        forward = cam.transform.forward;
        forward.y = 0;

        sideways = cam.transform.right;
        sideways.y = 0;
    }

    public override void Move()
    {
        Vector3 targetVelocity = forward * moveZ + sideways * moveX;
        targetVelocity *= moveSpeed;
        targetVelocity.y = rb.linearVelocity.y;

        rb.linearVelocity = Vector3.SmoothDamp(rb.linearVelocity, targetVelocity, ref refVel, smoothValue);

    }
}
