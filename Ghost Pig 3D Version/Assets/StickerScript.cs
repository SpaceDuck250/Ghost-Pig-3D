using UnityEngine;

public class StickerScript : MonoBehaviour
{
    public float radius;
    public float maxDistance;
    public LayerMask objectsLayer;

    //private void Start()
    //{
    //    //InvokeRepeating("SetOnTopObjectsAsChildren", 0.1f, 0.1f);
    //}

    //private void Update()
    //{
    //    SetOnTopObjectsAsChildren();
    //}

    private void OnCollisionEnter(Collision collision)
    {
        SetOnTopObjectsAsChildren();
    }

    private void OnCollisionExit(Collision collision)
    {
        SetOnTopObjectsAsChildren();
    }

    private void SetOnTopObjectsAsChildren()
    {
        RaycastHit[] hitsList = Physics.SphereCastAll(transform.position, radius, transform.up, maxDistance, objectsLayer); // Add a layer mask
        foreach (Transform child in transform)
        {
            child.transform.parent = null;
        }
        

        foreach (RaycastHit hit in hitsList)
        {
            if (!IsATransformableObject(hit.transform))
            {
                continue;
            }

            hit.transform.parent = transform;
        }
    }

    private bool IsATransformableObject(Transform obj)
    {
        TransformableObjScript transformerScript = obj.GetComponent<TransformableObjScript>();
        if (transformerScript != null)
        {
            return true;
        }

        return false;
    }

    
}
