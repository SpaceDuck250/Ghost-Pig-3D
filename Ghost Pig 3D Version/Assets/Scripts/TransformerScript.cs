using UnityEngine;

public class TransformerScript : MonoBehaviour
{
    public TransformableData transformData;

    public GameObject moveComponentObj;
    public MoveComponent moveComponent;

    public Transform componentContainer;

    public Rigidbody rb;

    private void Start()
    {
        if (transformData != null)
        {
            TransformToSomething(transformData);

        }
    }

    private void Update()
    {
        moveComponent.CheckInputs();
    }

    private void FixedUpdate()
    {
        moveComponent.Move();
    }

    private void TransformToSomething(TransformableData transformData)
    {
        this.transformData = transformData;
        moveComponentObj = transformData.moveComponentObj;

        SetupMoveComponent();

        SetupPosition();
        SetupCameraPosition();
        SetupNewPlayerBody();

    }

    // Have this in a separate class later or atleast rename;
    private void SetupMoveComponent()
    {
        GameObject newMoveComponent = Instantiate(moveComponentObj, componentContainer);
        moveComponent = newMoveComponent.GetComponent<MoveComponent>();
        moveComponent.AddRigidbody(rb);
        moveComponent.EditMoveValues(transformData);

    }

    private void SetupPosition()
    {

    }

    private void SetupCameraPosition()
    {

    }

    private void SetupNewPlayerBody()
    {

    }
}
