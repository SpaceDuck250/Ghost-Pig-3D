using UnityEngine;

public abstract class MoveComponent : MonoBehaviour
{
    public Rigidbody rb;
    public Camera cam;
    public Transform groundCheckTransform;

    public virtual void InitializeValues(Rigidbody rb, Camera cam, Transform groundCheckTransform)
    {
        this.rb = rb;
        this.cam = cam;
        this.groundCheckTransform = groundCheckTransform; 
    }

    public abstract void EditMoveValues(TransformableData transformableData);

    public abstract void CheckInputs();

    public abstract void Move();

}
