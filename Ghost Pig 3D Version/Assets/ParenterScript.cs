using UnityEngine;

public class ParenterScript : MonoBehaviour
{
    public LayerMask wallLayer;

    private void OnCollisionEnter(Collision collision)
    {

        print("collided before");


        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Zone")
        {
            return;
        }

        collision.transform.parent = transform;

        print("collided");
    }

    private void OnCollisionExit(Collision collision)
    {
        collision.transform.parent = null;
    }
}
