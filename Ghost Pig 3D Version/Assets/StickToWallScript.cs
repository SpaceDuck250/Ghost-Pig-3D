using UnityEngine;

public class StickToWallScript : MonoBehaviour
{
    public Rigidbody rb;
    public Vector3 stuckPosition;

    public bool stuck = false;

    public GameObject stickyBall;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            FreezePosition();

        }

        
    }

    private void FreezePosition()
    {
        GameObject newStickyBall = Instantiate(stickyBall, transform.position, Quaternion.identity);
    }
}
