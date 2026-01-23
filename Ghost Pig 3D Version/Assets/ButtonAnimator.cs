using UnityEngine;

public class ButtonAnimator : MonoBehaviour
{
    public Animator buttonAnimator;

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
        if (button != gameObject)
        {
            return;
        }

        buttonAnimator.SetBool("pressed", false);
    }

    private void OnButtonPressed(GameObject connectedPiston, GameObject button)
    {
        if (button != gameObject)
        {
            return;
        }

        buttonAnimator.SetBool("pressed", true);

    }
}
