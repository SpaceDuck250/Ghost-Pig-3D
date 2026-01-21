using UnityEngine;

public class FaceForwardScript : MonoBehaviour
{

    public Camera cam;

    private void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }


    private void Update()
    {
        transform.rotation = cam.transform.rotation;
    }


}
