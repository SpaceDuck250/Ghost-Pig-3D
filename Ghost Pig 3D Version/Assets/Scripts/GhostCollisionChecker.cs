using UnityEngine;
using System;

public class GhostCollisionChecker : MonoBehaviour
{
    public event Action<TransformableData> OnTransformInto;

    public GameObject selectedObject;

    private void OnTriggerEnter(Collider other)
    {
        TransformableObjScript transformableScript = other.gameObject.GetComponent<TransformableObjScript>();
        if (transformableScript == null)
        {
            return;
        }

        TransformableData data = transformableScript.transformableData;

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
