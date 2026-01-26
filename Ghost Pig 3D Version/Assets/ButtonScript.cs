using System;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public static event Action<GameObject, GameObject> OnButtonPressed;
    public static event Action<GameObject, GameObject> OnButtonReleased;

    public static event System.Action OnButtonFirstTimeClicked;

    public GameObject connectedPiston;

    private void OnTriggerEnter(Collider other)
    {
        if (other.isTrigger || other.gameObject.tag == "Player")
        {
            print("ghost button enter");

            return;
        }

        OnButtonFirstTimeClicked?.Invoke();
        OnButtonPressed?.Invoke(connectedPiston, gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.isTrigger || other.gameObject.tag == "Player")
        {
            print("ghost button");
            return;
        }

        OnButtonReleased?.Invoke(connectedPiston, gameObject);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.isTrigger || other.gameObject.tag == "Player")
        {
            return;
        }

        OnButtonPressed?.Invoke(connectedPiston, gameObject);
    }


}
