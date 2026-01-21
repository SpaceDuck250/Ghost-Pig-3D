using UnityEngine;

public class CameraBlurrerScript : MonoBehaviour
{
    public GameObject blurObject;

    private void OnTriggerEnter(Collider other)
    {
        blurObject.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        blurObject.SetActive(false);
    }
}
