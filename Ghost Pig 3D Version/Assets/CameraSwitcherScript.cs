using UnityEngine;

public class CameraSwitcherScript : MonoBehaviour
{
    public Transform player;

    private bool toggle = false;

    public TurnScript turnScript;
    public Transform thirdPersonRotatePoint;
    public Transform firstPersonRotatePoint;

    public Vector3 thirdPersonCamPosition;

    private void Start()
    {
        thirdPersonCamPosition = transform.localPosition;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            ToggleCameraModes();
        }
    }


    private void SwitchToFirstPerson()
    {
        turnScript.rotatePoint = firstPersonRotatePoint;
        transform.position = player.position; // wrong clown
    }

    private void SwitchToThirdPerson()
    {
        turnScript.rotatePoint = thirdPersonRotatePoint;
        transform.localRotation = Quaternion.Euler(0, 0, 0);
        transform.localPosition = thirdPersonCamPosition;
    }

    private void ToggleCameraModes()
    {
        if (!toggle)
        {
            SwitchToFirstPerson();
        }
        else
        {
            SwitchToThirdPerson();
        }

        toggle = !toggle;
    }
}
