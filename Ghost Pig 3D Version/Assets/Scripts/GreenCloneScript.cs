using UnityEngine;

public class GreenCloneScript : MonoBehaviour
{
    public GameObject parent;

    void Start()
    {
        GhostCollisionChecker.OnObjectEnter += OnObjectEnter;
        transform.localPosition = Vector3.zero;
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        GhostCollisionChecker.OnObjectEnter -= OnObjectEnter;
    }

    private void OnObjectEnter(GameObject obj)
    {

        if (obj == parent)
        {
            ShowGreenTint(true);
        }
        else
        {
            ShowGreenTint(false);
        }

    }

    private void ShowGreenTint(bool shown)
    {
        gameObject.SetActive(shown);
    }
}
