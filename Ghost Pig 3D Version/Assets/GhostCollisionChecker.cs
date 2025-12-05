using UnityEngine;
using System;

public class GhostCollisionChecker : MonoBehaviour
{
    public event Action<TransformableData> OnTransformInto;

    public GameObject selectedObject;

    private void OnTriggerEnter(Collider other)
    {
        TransformableData data = other.gameObject.GetComponent<TransformableObjScript>().transformableData;
        if (data != null) // change later
        {
            OnTransformInto?.Invoke(data);
        }

        print("entered");
        selectedObject = other.gameObject;
    }

    private void OnTriggerExit(Collider other)
    {
        print("exited");
        selectedObject = null;
    }
}
