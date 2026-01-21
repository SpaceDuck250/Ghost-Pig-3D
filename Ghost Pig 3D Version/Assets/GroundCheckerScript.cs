using UnityEngine;

public class GroundCheckerScript : MonoBehaviour
{
    public bool grounded = false;
    public static string groundCheckName = "GroundCheckObj";

    private void Start()
    {
        gameObject.name = groundCheckName;
    }

    private void OnTriggerEnter(Collider other)
    {

        grounded = true;
        print("hit ground");
    }

    private void OnTriggerExit(Collider other)
    {

        grounded = false;
        print("not on ground anymore");
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Zone")
        {
            return;
        }

        grounded = true;
    }

    
}
