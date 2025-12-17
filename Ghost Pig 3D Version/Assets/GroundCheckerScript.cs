using UnityEngine;

public class GroundCheckerScript : MonoBehaviour
{
    public bool grounded = false;

    private void OnTriggerEnter(Collider other)
    {
        grounded = true;
        print("hit ground");

    }

    private void OnTriggerExit(Collider other)
    {
        grounded = false;
    }
}
