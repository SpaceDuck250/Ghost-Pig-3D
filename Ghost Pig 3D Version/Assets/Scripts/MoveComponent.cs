using UnityEngine;

public abstract class MoveComponent : MonoBehaviour
{
    public Rigidbody rb;
    public Camera cam;
    public GameObject player;
    public GroundCheckerScript groundCheckScript;

    public virtual void InitializeValues(TransformableData transformableData, MoveContext moveContext)
    {
        SetupCommonValues(moveContext);

        EditScriptUniqueDataValues(transformableData);
    }

    public abstract void EditScriptUniqueDataValues(TransformableData transformableData);

    public abstract void CheckInputs();

    public abstract void Move();

    public void SetupCommonValues(MoveContext context)
    {
        this.rb = context.rb;
        this.cam = context.cam;
        this.player = context.player;
        this.groundCheckScript = context.groundCheckScript;
    }

}
