using UnityEngine;
using System;
using UnityEngine.XR;

public class TransformerUtilities : MonoBehaviour
{
    public TransformableData currentTransformData;

    public Transform componentContainer;

    public Rigidbody rb;
    public Camera cam;

    public PlayerMoveScript playerMoveScript;
    public GhostCollisionChecker collisionChecker;

    public Transform playerBodyContainer;
    public GameObject playerBody;

    [SerializeField]
    private GroundCheckerScript groundCheckScript;

    public void TransformToSomething(TransformableData transformData, GameObject obj, Vector3 newPlayerPosition)
    {
        ClearComponentContainer();
        ClearOldBody();

        this.currentTransformData = transformData;
        GameObject moveComponentObj = transformData.moveComponentObj;

        SetupPosition(newPlayerPosition);
        SetupNewPlayerBody(obj);
        SetupGravityAndMass(transformData.useGravity, transformData.mass);
        SetupMoveComponent(moveComponentObj);
    }

    // Have this in a separate class later or atleast rename;
    public void SetupMoveComponent(GameObject moveComponentObj)
    {
        GameObject newMoveComponent = Instantiate(moveComponentObj, componentContainer);

        MoveComponent moveComponent = newMoveComponent.GetComponent<MoveComponent>();

        moveComponent = newMoveComponent.GetComponent<MoveComponent>();

        MoveContext moveContext = new MoveContext(rb, cam, gameObject, groundCheckScript);
        moveComponent.InitializeValues(currentTransformData, moveContext);

        playerMoveScript.moveComponent = moveComponent;
        playerMoveScript.jumpComponent = moveComponent.GetComponent<IJump>();

    }

    private void SetupPosition(Vector3 newPos)
    {
        transform.position = newPos;
    }


    private void SetupNewPlayerBody(GameObject obj)
    {
        GameObject newPlayerBody = Instantiate(obj, transform.position, Quaternion.identity, playerBodyContainer);
        playerBody = newPlayerBody;

        Rigidbody rb = newPlayerBody.GetComponent<Rigidbody>();
        Destroy(rb);

        groundCheckScript = FindGroundCheckScript(newPlayerBody);

    }

    private void SetupGravityAndMass(bool useGravity, float newMass)
    {
        rb.useGravity = useGravity;
        rb.mass = newMass;
    }

    public void DestroyOldObject(GameObject obj)
    {
        Destroy(obj);
    }

    public void CreateOldObject(GameObject obj, Quaternion rotation)
    {
        GameObject oldObject = Instantiate(obj, transform.position, rotation);
    }

    public void ClearOldBody()
    {
        foreach (Transform child in playerBodyContainer)
        {
            Destroy(child.gameObject);
        }
    }

    public void ClearComponentContainer()
    {
        foreach (Transform child in componentContainer)
        {
            Destroy(child.gameObject);
        }
    }

    private GroundCheckerScript FindGroundCheckScript(GameObject parent)
    {
        Transform groundCheck = parent.transform.Find(GroundCheckerScript.groundCheckName);
        if (groundCheck == null)
        {
            return null;
        }

        GroundCheckerScript groundCheckScript = groundCheck.GetComponent<GroundCheckerScript>();
        return groundCheckScript; 
    }
}
