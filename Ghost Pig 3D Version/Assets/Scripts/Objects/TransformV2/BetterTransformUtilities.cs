using UnityEngine;

public class BetterTransformUtilities : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject ghostBody;

    public GameObject usedObjectBody; 

    public bool alreadyGhostPig;

    public Transform container;

    public PlayerMoveScript moveScript;

    public Camera cam;
    public CameraAdjusterScript camAdjuster;

    private void Start()
    {
        alreadyGhostPig = false;
    }

    public void TransformIntoSomething(GameObject transformObject)
    {
        SwitchBetweenObjectAndGhostPig();

        usedObjectBody = transformObject;

        Vector3 objectPosition = transformObject.transform.position;
        SetupCamera(objectPosition, transformObject.transform);

        Rigidbody rb = transformObject.GetComponent<Rigidbody>();
        if (rb != null)
        {
            print("did");
            SetupMovement(transformObject, rb);
        }


    }

    private void SetupCamera(Vector3 objectPosition, Transform objectTransform)
    {
        transform.position = objectPosition;
        transform.parent = objectTransform;
        camAdjuster.player = usedObjectBody.transform;
    }

    private void SetupMovement(GameObject transformObject, Rigidbody newRb)
    {
        rb = newRb;

        SetupMoveComponent(transformObject);

        
    }

    private void SetupMoveComponent(GameObject transformObject)
    {
        TransformableData transformData = transformObject.GetComponent<TransformableObjScript>().transformableData;
        GameObject moveComponentObject = transformData.moveComponentObj;

        GameObject newMoveComponentObj = Instantiate(moveComponentObject, container);

        GroundCheckerScript groundCheck = FindGroundCheckScript(transformObject);
        MoveContext moveContext = new MoveContext(rb, cam, usedObjectBody, groundCheck);

        MoveComponent moveComponent = newMoveComponentObj.GetComponent<MoveComponent>();
        moveComponent.InitializeValues(transformData, moveContext);

        moveScript.moveComponent = moveComponent;
        moveScript.jumpComponent = newMoveComponentObj.GetComponent<IJump>();

        print("also did");
    }
   

    private void ShowGhostBody(bool value)
    {
        ghostBody.SetActive(value);
    }

    private GroundCheckerScript FindGroundCheckScript(GameObject parent)
    {
        Transform groundCheck = parent.transform.Find(GroundCheckerScript.groundCheckName);
        if (groundCheck == null)
        {
            return null;
        }

        GroundCheckerScript groundCheckScript = groundCheck.GetComponent<GroundCheckerScript>();
        print(groundCheckScript);
        return groundCheckScript;
    }

    private void SwitchBetweenObjectAndGhostPig()
    {
        if (alreadyGhostPig)
        {
            ShowGhostBody(false);
            //if (objectBody != null)
            //{
            //    Vector3 oldObjectPosition = objectBody.transform.position;
            //    TeleportGhostPigToObjectLocation(oldObjectPosition);
            //}
        }
        else
        {

            //if (usedObjectBody != null) // obj body should be the obj
            //{
            //    //Vector3 oldObjectPosition = usedObjectBody.transform.position;
            //    //TeleportGhostPigToObjectLocation(oldObjectPosition);
            //}

            ShowGhostBody(true);
        }

        alreadyGhostPig = !alreadyGhostPig;
    }

    private void TeleportGhostPigToObjectLocation(Vector3 newPosition)
    {
        ghostBody.transform.position = newPosition;
    }
}
