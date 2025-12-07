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

    private void Start()
    {
        Cursor.visible = false;
    }

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
    }

    private void SetRotation()
    {

    }
}
