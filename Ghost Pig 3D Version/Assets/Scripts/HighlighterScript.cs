using UnityEngine;

public class HighlighterScript : MonoBehaviour
{
    private GameObject objectShape;

    private static float scaleModifier = 1.03f;

    public static Material greenTint;

    public GhostCollisionChecker collisionChecker;

    private GameObject greenTintObj;


    void Start()
    {
        GhostCollisionChecker.OnObjectEnter += OnObjectEnter;

        objectShape = gameObject;
        greenTint = Resources.Load<Material>("Materials/GreenTint");

        CreateGreenClone();


    }

    private void OnDestroy()
    {
        GhostCollisionChecker.OnObjectEnter -= OnObjectEnter;

    }

    private void OnObjectEnter(GameObject obj)
    {
        if (obj == gameObject)
        {
            ShowGreenTint(true);
        }
        else
        {
            ShowGreenTint(false);
        }

    }

    private void CreateGreenClone()
    {
        GameObject greenClone = Instantiate(objectShape, transform.position, Quaternion.identity, transform);

        greenClone.transform.localScale *= scaleModifier;

        MeshRenderer meshRenderer = greenClone.GetComponent<MeshRenderer>();
        meshRenderer.material = greenTint;

        TransformableObjScript transformableScript = greenClone.GetComponent<TransformableObjScript>();
        Destroy(transformableScript);

        greenTintObj = greenClone;

        greenClone.SetActive(false);
    }

    private void ShowGreenTint(bool shown)
    {
        greenTintObj.SetActive(shown);
    }


}
