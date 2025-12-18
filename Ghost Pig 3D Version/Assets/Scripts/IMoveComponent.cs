using UnityEngine;

public abstract class MoveComponent : MonoBehaviour
{
    public Rigidbody rb;
    public Camera cam;
    public GameObject player;
    public GroundCheckerScript groundCheckScript;

    public virtual void InitializeValues(TransformableData transformableData, Rigidbody rb, Camera cam, GameObject player, GroundCheckerScript groundCheckScript)
    {
        SetupCommonData(transformableData, rb, cam, player, groundCheckScript);

        EditScriptUniqueDataValues(transformableData);
    }

    public abstract void EditScriptUniqueDataValues(TransformableData transformableData);

    public abstract void CheckInputs();

    public abstract void Move();

    public abstract void Jump();

    public void SetupCommonData(TransformableData transformableData, Rigidbody rb, Camera cam, GameObject player, GroundCheckerScript groundCheckScript)
    {
        this.rb = rb;
        this.cam = cam;
        this.player = player;
        this.groundCheckScript = groundCheckScript;

    }

}
