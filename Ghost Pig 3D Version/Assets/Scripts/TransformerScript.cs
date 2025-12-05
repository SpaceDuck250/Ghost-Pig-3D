using UnityEngine;

public class TransformerScript : MonoBehaviour
{
    public TransformableData currentTransformableData;

    public GameObject moveComponentObj;
    public MoveComponent moveComponent;

    public Transform componentContainer;

    private void Start()
    {
        GameObject newMoveComponent = Instantiate(moveComponentObj, componentContainer);
        moveComponent = newMoveComponent.GetComponent<MoveComponent>();
    }

    private void TransformToSomething(TransformableData transformData)
    {
        currentTransformableData = transformData;

    }

    // Have this in a separate class later or atleast rename;
    public void SetupMoveComponent()
    {
        moveComponent.AddRigidbody()
    }
}
