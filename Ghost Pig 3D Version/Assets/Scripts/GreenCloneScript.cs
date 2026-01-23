using Unity.VisualScripting;
using UnityEngine;

public class GreenCloneScript : MonoBehaviour
{
    public GameObject parent;

    void Start()
    {
        GhostCollisionChecker.OnObjectEnter += OnObjectEnter;
        TransformerScript.OnTransformBackIntoGhostPig += OnTransformBackIntoGhostPig;
        transform.localPosition = Vector3.zero;
        gameObject.SetActive(false);

        //DestroyChildren();
    }

    private void OnDestroy()
    {
        GhostCollisionChecker.OnObjectEnter -= OnObjectEnter;
        TransformerScript.OnTransformBackIntoGhostPig -= OnTransformBackIntoGhostPig;

    }

    public void OnTransformBackIntoGhostPig()
    {
        //if (this == null)
        //{
        //    return;
        //}

        ShowGreenTint(false);
    }

    private void OnObjectEnter(GameObject objectEntered)
    {

        if (objectEntered == parent || CheckIfWeAreGreenChild(objectEntered))
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

    private bool CheckIfWeAreGreenChild(GameObject enteredObj)
    {
        if (enteredObj == null)
        {
            return false;
        }

        Transform enteredTransform = enteredObj.transform;

        if (enteredTransform.childCount == 0)
        {
            return false;
        }

        foreach (Transform child in enteredTransform)
        {
            if (transform.parent == child)
            {
                return true;
            }
        }

        return false;
    }


}
