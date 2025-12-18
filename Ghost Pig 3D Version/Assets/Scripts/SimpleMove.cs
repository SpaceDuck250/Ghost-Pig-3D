using UnityEngine;

public class SimpleObjectMove : MoveComponent
{
    private float moveX;
    private float moveZ;

    private Vector3 refVelocity;

    public float moveSpeed;
    public float smoothValue;

    private Vector3 forward;
    private Vector3 sideways;

    private bool jump;
    public float jumpForce;

    public override void EditScriptUniqueDataValues(TransformableData moveData)
    {
        moveSpeed = moveData.moveSpeed;
        smoothValue = moveData.smoothValue;
        jumpForce = moveData.jumpForce;
    }

    public override void CheckInputs()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        moveZ = Input.GetAxisRaw("Vertical");


        forward = cam.transform.forward;
        forward.y = 0;

        sideways = cam.transform.right;
        sideways.y = 0;

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

    }

    public override void Move()
    {
        Vector3 targetVelocity = forward * moveZ + sideways * moveX;
        targetVelocity *= moveSpeed;
        targetVelocity.y = rb.linearVelocity.y;

        rb.linearVelocity = Vector3.SmoothDamp(rb.linearVelocity, targetVelocity, ref refVelocity, smoothValue * Time.fixedDeltaTime);
    }

    public override void Jump()
    {
        bool grounded = groundCheckScript.grounded;
        if (jump && grounded)
        {
            Vector3 jumpVector = Vector3.up * jumpForce;
            rb.AddForce(jumpVector, ForceMode.Impulse);
            jump = false;

            print("jumped");
        }

        jump = false;
    }

}
