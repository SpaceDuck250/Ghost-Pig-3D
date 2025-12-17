using UnityEngine;

public abstract class MoveComponent : MonoBehaviour
{
    public Rigidbody rb;
    public Camera cam;
    public GameObject player;

    public virtual void InitializeValues(TransformableData transformableData, Rigidbody rb, Camera cam, GameObject player)
    {
        SetupCommonData(transformableData, rb, cam, player);

        EditScriptUniqueDataValues(transformableData);
    }

    public abstract void EditScriptUniqueDataValues(TransformableData transformableData);

    public abstract void CheckInputs();

    public abstract void Move();

    public void SetupCommonData(TransformableData transformableData, Rigidbody rb, Camera cam, GameObject player)
    {
        this.rb = rb;
        this.cam = cam;

        this.player = player;
    }

}
