using UnityEngine;

public class BouncyScript : MonoBehaviour
{
    public float bounceStrength;
    public float maxBounceMagnitude;

    private void OnCollisionEnter(Collision other)
    {
        print("collided with slab");

        Vector3 enterDirection = (other.transform.position - transform.position).normalized;
        if (CheckIfFallOnto(enterDirection))
        {
            print("fell on slab");
            Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                ApplyUpForceDependingOnVelocity(rb);
            }
        }
    }

    private bool CheckIfFallOnto(Vector3 enterDirection)
    {

        float dotproduct = Vector3.Dot(enterDirection, transform.up);

        if (dotproduct > 0.5f)
        {
            return true;
        }

        return false;
    }

    private void ApplyUpForceDependingOnVelocity(Rigidbody rb)
    {
        float bounceAmplifier = bounceStrength * Mathf.Abs(rb.linearVelocity.y);
        //bounceAmplifier = Mathf.Clamp(bounceAmplifier, 0, maxBounceMagnitude);

        print("force amount" +  bounceAmplifier);

        Vector3 upForce = Vector3.up * bounceAmplifier;

        rb.AddForce(upForce, ForceMode.Impulse);
    }
}
