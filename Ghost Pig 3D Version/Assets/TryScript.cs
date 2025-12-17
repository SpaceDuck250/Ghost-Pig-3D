using UnityEngine;

public class TryScript : MonoBehaviour
{
    public Vector3 cubeHalfSize;
    public LayerMask okayMask;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawCube(transform.position - new Vector3(0, 0.2f, 0), cubeHalfSize);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            CheckGrounded();
        }
    }

    private bool CheckGrounded()
    {
        //float checkDistance = 1f;
        //bool hit = Physics.BoxCast(transform.position, cubeHalfSize, Vector3.down, Quaternion.identity, checkDistance, okayMask);
        //print(hit);
        return true;
    }
}
