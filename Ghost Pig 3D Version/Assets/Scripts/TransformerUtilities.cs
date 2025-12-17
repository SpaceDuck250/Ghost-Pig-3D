using UnityEngine;
using System;

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

    public void TransformToSomething(TransformableData transformData, GameObject obj, Vector3 newPlayerPosition)
    {
        ClearComponentContainer();
        ClearOldBody();

        this.currentTransformData = transformData;
        GameObject moveComponentObj = transformData.moveComponentObj;

        SetupMoveComponent(moveComponentObj);


        SetupPosition(newPlayerPosition);
        SetupNewPlayerBody(obj);
        SetupGravity(transformData.useGravity);
    }

    // Have this in a separate class later or atleast rename;
    public void SetupMoveComponent(GameObject moveComponentObj)
    {
        GameObject newMoveComponent = Instantiate(moveComponentObj, componentContainer);

        MoveComponent moveComponent = newMoveComponent.GetComponent<MoveComponent>();

        moveComponent = newMoveComponent.GetComponent<MoveComponent>();
        moveComponent.InitializeValues(currentTransformData, rb, cam, gameObject);

        playerMoveScript.moveComponent = moveComponent;

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
        ClearGreenClones(newPlayerBody.transform);
    }

    private void SetupGravity(bool useGravity)
    {
        rb.useGravity = useGravity;
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

    public void ClearGreenClones(Transform obj)
    {
        foreach (Transform child in obj)
        {
            Destroy(child.gameObject);
        }
    }
}
