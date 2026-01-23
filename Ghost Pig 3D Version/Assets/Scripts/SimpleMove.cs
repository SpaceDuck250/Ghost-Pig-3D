using UnityEngine;
using System.Collections;

public class SimpleObjectMove : MoveComponent, IJump
{
    public static event System.Action OnObjectMove;
    public static event System.Action OnObjectStopMove;

    private float moveX;
    private float moveZ;

    private Vector3 refVelocity;

    public float moveSpeed;
    public float smoothValue;

    private Vector3 forward;
    private Vector3 sideways;

    private bool jump;
    public float jumpForce;

    private float downwardsFallForce = 0.05f;

    private bool ignoreGrounded = false;

    private float coyoteTimer;
    private float coyoteTime = 0.3f;

    private float bufferTimer;
    private float bufferTime = 0.5f;

    private bool alreadyIgnoring = false;

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

        TryJumping();

        if (CheckIfMoving())
        {
            OnObjectMove?.Invoke();
        }
        else
        {
            OnObjectStopMove?.Invoke();
        }
    }

    public override void Move()
    {
        if (CheckIfAtApex())
        {
            rb.AddForce(Vector3.down * downwardsFallForce, ForceMode.Impulse);
        }

        Vector3 targetVelocity = forward * moveZ + sideways * moveX;
        targetVelocity *= moveSpeed;
        targetVelocity.y = rb.linearVelocity.y;

        rb.linearVelocity = Vector3.SmoothDamp(rb.linearVelocity, targetVelocity, ref refVelocity, smoothValue * Time.fixedDeltaTime);
    }

    public bool Jump()
    {
        bool jumped = false;

        if (bufferTimer > 0 && coyoteTimer > 0)
        {
            jumped = true;

            coyoteTimer = 0;
            bufferTimer = 0;

            Vector3 startVelocity = new Vector3(rb.linearVelocity.x, 0, rb.linearVelocity.z);
            rb.linearVelocity = startVelocity;

            Vector3 jumpVector = Vector3.up * jumpForce;
            rb.AddForce(jumpVector, ForceMode.Impulse);

            StartCoroutine(IgnoreGrounded());

            print(coyoteTimer + " coyote");
        }

        return jumped;
    }

    private void TryJumping()
    {
        bool grounded = groundCheckScript.grounded;
        if (!ignoreGrounded && grounded)
        {
            coyoteTimer = coyoteTime;
        }
        else
        {
            coyoteTimer -= Time.deltaTime;
            coyoteTimer = Mathf.Clamp(coyoteTimer, 0, coyoteTime);
        }

        if (Input.GetButtonDown("Jump"))
        {
            bufferTimer = bufferTime;
        }
        else
        {
            bufferTimer -= Time.deltaTime;
            bufferTimer = Mathf.Clamp(bufferTimer, 0, bufferTime);
        }
    }

    // To fix double jump bug
    private IEnumerator IgnoreGrounded()
    {
        if (!alreadyIgnoring)
        {
            alreadyIgnoring = true;
            ignoreGrounded = true;
            groundCheckScript.grounded = false;

            float waitTime = 0.5f;
            yield return new WaitForSeconds(waitTime);

            ignoreGrounded = false;

            alreadyIgnoring = false;
        }
    }

    private bool CheckIfAtApex()
    {
        if (!groundCheckScript.grounded && Mathf.Round(rb.linearVelocity.y) == 0)
        {
            return false;
        }

        return true;
    }

    private bool CheckIfMoving()
    {
        if (alreadyIgnoring)
        {
            return false;
        }

        Vector3 groundVelocity = rb.linearVelocity;
        groundVelocity.y = 0;

        float groundSpeed = groundVelocity.magnitude;

        float minMoveSpeed = 0.5f;
        if (groundSpeed >= minMoveSpeed && groundCheckScript.grounded)
        {
            return true;
        }

        return false;
    }

}
