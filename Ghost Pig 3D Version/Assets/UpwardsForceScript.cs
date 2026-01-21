using UnityEngine;

public class UpwardsForceScript : MonoBehaviour
{
    public float upwardsForceAmount;
    public float maxUpVelocity;

    // Already starts off as the balloons rb;
    public Rigidbody rb;


    private void Start()
    {
        GhostCollisionChecker.OnTransformInto += OnTransformInto;
    }

    private void OnTransformInto(TransformableData data, GameObject obj)
    {
        if (CheckIfTransformedIntoBalloon(obj))
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            rb = player.GetComponent<Rigidbody>();
        }
    }

    private void OnDestroy()
    {
        GhostCollisionChecker.OnTransformInto -= OnTransformInto;
    }

    private void Update()
    {
        if (rb == null)
        {
            return;
        }

        ApplyUpwardsForce();
    }

    private void ApplyUpwardsForce()
    {
        Vector3 upwardsForce = Vector3.up * upwardsForceAmount;
        rb.AddForce(upwardsForce, ForceMode.Acceleration);

        ClampUpForce();
    }

    private bool CheckIfTransformedIntoBalloon(GameObject obj)
    {
        if (obj.name == gameObject.name)
        {
            return true;
        }

        return false;
    }

    private void ClampUpForce()
    {
        Vector3 upForce = rb.linearVelocity;
        upForce.x = 0;
        upForce.z = 0;

        float upLength = upForce.y; // or simply just the y

        if (upLength >= maxUpVelocity)
        {
            Vector3 newVelocity = rb.linearVelocity;
            newVelocity.y = maxUpVelocity;

            rb.linearVelocity = newVelocity;
        }
    }

}
