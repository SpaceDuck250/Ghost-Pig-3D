using UnityEngine;

public class CameraSwitcherScript : MonoBehaviour
{
    public Transform player;

    public bool inFirstPersonMode = false;

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
        transform.position = player.position;
    }

    public void SwitchToThirdPerson()
    {
        turnScript.rotatePoint = thirdPersonRotatePoint;
        transform.localRotation = Quaternion.Euler(0, 0, 0);
        transform.localPosition = thirdPersonCamPosition;
    }

    private void ToggleCameraModes()
    {
        if (!inFirstPersonMode)
        {
            SwitchToFirstPerson();
        }
        else
        {
            SwitchToThirdPerson();
        }

        inFirstPersonMode = !inFirstPersonMode;
    }
}
