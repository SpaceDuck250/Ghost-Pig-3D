using System;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public static event Action<GameObject, GameObject> OnButtonPressed;
    public static event Action<GameObject, GameObject> OnButtonReleased;

    public GameObject connectedPiston;

    private void OnTriggerEnter(Collider other)
    {
        if (other.isTrigger)
        {
            print("ghost button enter");

            return;
        }

        OnButtonPressed?.Invoke(connectedPiston, gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.isTrigger)
        {
            print("ghost button");
            return;
        }

        OnButtonReleased?.Invoke(connectedPiston, gameObject);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.isTrigger)
        {
            return;
        }

        OnButtonPressed?.Invoke(connectedPiston, gameObject);
    }


}
