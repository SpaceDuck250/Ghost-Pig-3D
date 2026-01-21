using System;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public static event Action<GameObject> OnButtonPressed;
    public static event Action<GameObject> OnButtonReleased;

    public GameObject connectedPiston;

    private void OnTriggerEnter(Collider other)
    {
        OnButtonPressed?.Invoke(connectedPiston);
    }

    private void OnTriggerExit(Collider other)
    {
        OnButtonReleased?.Invoke(connectedPiston);
    }
}
