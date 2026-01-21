using UnityEngine;

public class CameraAdjusterScript : MonoBehaviour
{
    public Camera cam;
    public float shootDistance;

    public CameraSwitcherScript cameraSwitcher;

    public Transform player;

    public LayerMask hittableLayer;

    private void Update()
    {
        if (cameraSwitcher.inFirstPersonMode)
        {
            return;
        }

        Vector3 surfacePoint;

        TryHittingSurface(out surfacePoint);
        cam.transform.position = surfacePoint;
        print("Adjusted");

    }

    public bool TryHittingSurface(out Vector3 hitPoint)
    {
        Vector3 shootDirection = -cam.transform.forward;

        Vector3 upOffset = player.up * 0;
        Vector3 shootOrigin = player.position + upOffset;

        RaycastHit hitInfo;
        bool hit = Physics.Raycast(shootOrigin, shootDirection, out hitInfo, shootDistance, hittableLayer);

        if (!hit || hitInfo.collider.gameObject.tag == "MainCamera")
        {
            Vector3 defaultCameraPosition = shootOrigin + (shootDirection * shootDistance);

            hitPoint = defaultCameraPosition;
            return false;
        }

        Vector3 offset = -shootDirection * 0.2f;
        hitPoint = hitInfo.point + offset;
        return true;
    }
}
