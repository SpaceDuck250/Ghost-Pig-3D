using UnityEngine;

public class ButtonListenerScript : MonoBehaviour
{
    public PistonMoveablePartScript pistonScript;

    private void Start()
    {
        ButtonScript.OnButtonPressed += OnButtonPressed;
        ButtonScript.OnButtonReleased += OnButtonReleased;
    }

    private void OnDestroy()
    {
        ButtonScript.OnButtonPressed -= OnButtonPressed;
        ButtonScript.OnButtonReleased -= OnButtonReleased;
    }

    private void OnButtonReleased(GameObject connectedPiston, GameObject button)
    {
        if (!CheckIfThisIsTheAssociatedPiston(connectedPiston))
        {
            return;
        }

        pistonScript.buttonPressed = false;
    }

    private void OnButtonPressed(GameObject connectedPiston, GameObject button)
    {
        if (!CheckIfThisIsTheAssociatedPiston(connectedPiston))
        {
            return;
        }

        pistonScript.buttonPressed = true;
    }

    private bool CheckIfThisIsTheAssociatedPiston(GameObject connectedPiston)
    {
        if (connectedPiston == gameObject)
        {
            return true;
        }

        return false;
    }
}
