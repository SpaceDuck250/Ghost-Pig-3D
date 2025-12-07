using UnityEngine;

public class HighlighterScript : MonoBehaviour
{
    private GameObject objectShape;

    private static float scaleModifier = 1.03f;

    public static Material greenTint;

    void Start()
    {
        objectShape = gameObject;
        greenTint = Resources.Load<Material>("Materials/GreenTint");

        CreateGreenClone();
    }

    private void CreateGreenClone()
    {
        GameObject greenClone = Instantiate(objectShape, transform.position, Quaternion.identity, transform);

        greenClone.transform.localScale *= scaleModifier;

        MeshRenderer meshRenderer = greenClone.GetComponent<MeshRenderer>();
        meshRenderer.material = greenTint;

        greenClone.SetActive(false);


    }


}
