using UnityEngine;

public abstract class MoveComponent : MonoBehaviour
{
    public Rigidbody rb;

    public virtual void AddRigidbody(Rigidbody rb)
    {
        this.rb = rb;
    }

    public abstract void EditMoveValues(TransformableData transformableData);

    public abstract void CheckInputs();

    public abstract void Move();

}
