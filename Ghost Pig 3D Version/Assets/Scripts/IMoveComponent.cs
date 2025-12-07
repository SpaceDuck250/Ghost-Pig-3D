using UnityEngine;

public abstract class MoveComponent : MonoBehaviour
{
    public Rigidbody rb;
    public Camera cam;

    public virtual void InitializeValues(Rigidbody rb, Camera cam)
    {
        this.rb = rb;
        this.cam = cam;
    }

    public abstract void EditMoveValues(TransformableData transformableData);

    public abstract void CheckInputs();

    public abstract void Move();

}
