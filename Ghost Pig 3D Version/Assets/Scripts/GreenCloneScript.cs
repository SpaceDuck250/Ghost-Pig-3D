using UnityEngine;

public class GreenCloneScript : MonoBehaviour
{
    public GameObject parent;

    void Start()
    {
        GhostCollisionChecker.OnObjectEnter += OnObjectEnter;
        //TransformerScript.OnTransformBackIntoGhostPig += OnTransformBackIntoGhostPig;
        transform.localPosition = Vector3.zero;
        gameObject.SetActive(false);

        //DestroyChildren();
    }

    private void OnDestroy()
    {
        GhostCollisionChecker.OnObjectEnter -= OnObjectEnter;
    }

    //public void OnTransformBackIntoGhostPig()
    //{
    //    ShowGreenTint(false);
    //}

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

    //private void DestroyChildren()
    //{
    //    if (transform.childCount == 0)
    //    {
    //        return;
    //    }

    //    foreach (Transform child in transform)
    //    {
    //        Destroy(child.gameObject);
    //    }
    //}
}
