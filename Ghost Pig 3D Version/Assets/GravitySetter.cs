using UnityEngine;

public class GravitySetter : MonoBehaviour
{
    public Vector3 worldGravity;

    private void Start()
    {
        Physics.gravity = worldGravity;
    }
}
