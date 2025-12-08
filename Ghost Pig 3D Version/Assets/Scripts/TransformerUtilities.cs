using UnityEngine;
using System;

public class TransformerUtilities : MonoBehaviour
{
    public TransformableData transformData;

    public Transform componentContainer;

    public Rigidbody rb;
    public Camera cam;

    public PlayerMoveScript playerMoveScript;
    public GhostCollisionChecker collisionChecker;

    public Transform playerBody;

    public void TransformToSomething(TransformableData transformData, GameObject obj)
    {
        this.transformData = transformData;
        GameObject moveComponentObj = transformData.moveComponentObj;

        SetupMoveComponent(moveComponentObj);


        SetupPosition(obj);
        SetupNewPlayerBody(obj);

    }

    // Have this in a separate class later or atleast rename;
    public void SetupMoveComponent(GameObject moveComponentObj)
    {
        GameObject newMoveComponent = Instantiate(moveComponentObj, componentContainer);

        MoveComponent moveComponent = newMoveComponent.GetComponent<MoveComponent>();

        moveComponent = newMoveComponent.GetComponent<MoveComponent>();
        moveComponent.InitializeValues(rb, cam);
        moveComponent.EditMoveValues(transformData);

        playerMoveScript.moveComponent = moveComponent;

    }

    private void SetupPosition(GameObject obj)
    {
        transform.position = obj.transform.position;
    }


    private void SetupNewPlayerBody(GameObject obj)
    {
        GameObject newPlayerBody = Instantiate(obj, transform.position, Quaternion.identity, playerBody);

    }

    public void DestroyOldObject(GameObject obj)
    {
        Destroy(obj);
    }

    public void ClearOldBody()
    {
        foreach (Transform child in playerBody)
        {
            Destroy(child.gameObject);
        }
    }
}
