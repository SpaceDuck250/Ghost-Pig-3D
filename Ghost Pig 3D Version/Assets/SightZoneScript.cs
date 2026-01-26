using UnityEngine;
using System;

public class SightZoneScript : MonoBehaviour
{
    public static event Action<float, float> OnSightEnter;
    public static event System.Action OnSightExit;

    public float damageAmount;
    public float repeatTime;


    private void OnTriggerEnter(Collider other)
    {
        TransformableObjScript transformerScript = other.gameObject.GetComponent<TransformableObjScript>();
        if (transformerScript == null)
        {
            return;
        }

        OnSightEnter?.Invoke(damageAmount, repeatTime);
    }

    private void OnTriggerExit(Collider other)
    {
        TransformableObjScript transformerScript = other.gameObject.GetComponent<TransformableObjScript>();
        if (transformerScript == null)
        {
            return;
        }

        OnSightExit?.Invoke();
    }
}
