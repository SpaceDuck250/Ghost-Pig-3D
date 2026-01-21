using UnityEngine;

public class TurnScript : MonoBehaviour
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

        //TransformerScript.OnTransformBackIntoGhostPig += OnTransformBackIntoGhostPig;
        //GhostCollisionChecker.OnTransformInto += OnTransformIntoObject;
    }


    //private void OnDestroy()
    //{
    //    //TransformerScript.OnTransformBackIntoGhostPig -= OnTransformBackIntoGhostPig;
    //    //GhostCollisionChecker.OnTransformInto -= OnTransformIntoObject;
    //}

    private void Update()
    {
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");

        RotateY();
        RotateX();
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
        transform.Rotate(rotateVectorX);
        // just change rotateObject to transform
    }

    //public void OnTransformBackIntoGhostPig()
    //{
    //    Transform ghostPigBody = transformUtilities.ghostBody.transform;

    //    ghostPigBody.rotation = transform.rotation;

    //    Quaternion sameRotationAsGhostBody = Quaternion.Euler(0, 0, 0);
    //    transform.localRotation = sameRotationAsGhostBody;

    //    rotateObject = ghostPigBody;
    //}

    //private void OnTransformIntoObject(TransformableData data, GameObject obj)
    //{
    //    rotateObject = obj.transform;
    //}

}
