using UnityEngine;

public class GhostMove : MoveComponent
{
    private float moveX;
    private float moveZ;

    private Vector3 refVelocity;

    public float moveSpeed;
    public float smoothValue;

    private Vector3 forward;
    private Vector3 sideways;

    private float moveY;


    public override void EditScriptUniqueDataValues(TransformableData moveData)
    {
        moveSpeed = moveData.moveSpeed;
        smoothValue = moveData.smoothValue;
    }

    public override void CheckInputs()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        moveZ = Input.GetAxisRaw("Vertical");

        moveY = Input.GetAxisRaw("UpDown");


        forward = cam.transform.forward;
        forward.y = 0;

        sideways = cam.transform.right;
        sideways.y = 0;

    }

    public override void Move()
    {
        Vector3 targetVelocity = forward * moveZ + sideways * moveX + Vector3.up * moveY;
        targetVelocity *= moveSpeed;

        rb.linearVelocity = Vector3.SmoothDamp(rb.linearVelocity, targetVelocity, ref refVelocity, smoothValue * Time.fixedDeltaTime);
    }

   
}
