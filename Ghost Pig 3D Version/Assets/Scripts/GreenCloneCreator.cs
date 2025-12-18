using UnityEngine;

public class GreenCloneCreator : MonoBehaviour
{
    private GameObject objectShape;

    private static float scaleModifier = 1.03f;

    public static Material greenTint;

    private Rigidbody rb;

    void Start()
    {

        objectShape = gameObject;
        greenTint = Resources.Load<Material>("Materials/GreenTint");
        CreateGreenClone();
    }

    private void CreateGreenClone()
    {
        GameObject greenClone = Instantiate(objectShape, transform.position, transform.localRotation, transform);

        greenClone.transform.localScale *= scaleModifier;

        MeshRenderer meshRenderer = greenClone.GetComponent<MeshRenderer>();
        meshRenderer.material = greenTint;

        Rigidbody rb = greenClone.GetComponent<Rigidbody>();
        Destroy(rb);

        DestroyAllScript(greenClone);

        greenClone.AddComponent<GreenCloneScript>();
        greenClone.GetComponent<GreenCloneScript>().parent = gameObject;
    }

    private void DestroyAllScript(GameObject obj)
    {
        MonoBehaviour[] scriptList = obj.GetComponents<MonoBehaviour>();

        foreach (MonoBehaviour script in scriptList)
        {
            Destroy(script);
        }
    }

}
