using UnityEngine;

public class BetterTurnScript : MonoBehaviour
{
    private float mouseX;
    private float mouseY;

    private float rotateY = 0;
    public float yRange;

    public Camera cam;

    public float sensitivity;

    public Transform rotatePoint;
    public CameraSwitcherScript camSwitcher;

    public Transform rotateObject;
    public BetterTransformUtilities transformUtilities;

    private void Start()
    {
        //Cursor.visible = false;
        rotatePoint = camSwitcher.thirdPersonRotatePoint;

        TransformerScript.OnTransformBackIntoGhostPig += OnTransformBackIntoGhostPig;
        GhostCollisionChecker.OnTransformInto += OnTransformIntoObject;
    }


    private void OnDestroy()
    {
        TransformerScript.OnTransformBackIntoGhostPig -= OnTransformBackIntoGhostPig;
        GhostCollisionChecker.OnTransformInto -= OnTransformIntoObject;
    }

    private void Update()
    {
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");

        RotateY();
        RotateX();

        ConstantlyRotateAndMoveGhostPigBody();
    }

    private void RotateY()
    {
        rotateY -= mouseY * Time.deltaTime * sensitivity;
        rotateY = Mathf.Clamp(rotateY, -yRange, yRange);
        rotatePoint.transform.localRotation = Quaternion.Euler(rotateY, 0, 0);
    }

    private void RotateX()
    {
        Vector3 rotateVectorX = Vector3.up * mouseX * Time.deltaTime * sensitivity;
        //transform.Rotate(rotateVectorX);

        rotateObject.Rotate(rotateVectorX);

        // just change rotateObject to transform
    }

    public void OnTransformBackIntoGhostPig()
    {
        Transform ghostPigBody = transformUtilities.ghostBody.transform;

        //ghostPigBody.rotation = transformUtilities.previousObjectBody.transform.rotation;
        //ghostPigBody.rotation = transform.rotation;


        Quaternion sameRotationAsGhostBody = Quaternion.Euler(0, 0, 0);
        transform.localRotation = sameRotationAsGhostBody;


        rotateObject = ghostPigBody;
        //rotateObject = transform;
    }

    private void OnTransformIntoObject(TransformableData data, GameObject obj)
    {
        rotateObject = obj.transform;
    }

    private void ConstantlyRotateAndMoveGhostPigBody()
    {
        if (transformUtilities.alreadyGhostPig)
        {
            return;
        }

        Transform ghostPigBody = transformUtilities.ghostBody.transform;

        ghostPigBody.transform.rotation = transform.rotation;

        Vector3 objectPosition = transformUtilities.usedObjectBody.transform.position;
        ghostPigBody.transform.position = objectPosition;

    }

}
