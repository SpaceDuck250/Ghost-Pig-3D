using UnityEngine;

public class FrictionScript : MonoBehaviour
{
    public PhysicsMaterial material;

    private void Start()
    {
        if (CheckIfAlreadyMadeFrictionSurface())
        {
            return;
        }

        CreateFrictionSurface();
    }

    private void CreateFrictionSurface()
    {
        GameObject frictionSurface = Instantiate(gameObject, transform.position, Quaternion.identity, transform.parent);

        frictionSurface.tag = "FrictionSurface";

        float yOffset = 0f;

        frictionSurface.transform.position += new Vector3(0, yOffset, 0);

        Collider collider = frictionSurface.GetComponent<Collider>();

        collider.isTrigger = false;

        collider.material = material;
    }

    private bool CheckIfAlreadyMadeFrictionSurface()
    {
        foreach (Transform child in transform.parent)
        {
            if (child.gameObject.tag == "FrictionSurface")
            {
                return true;
            }
        }

        return false;
    }
}
