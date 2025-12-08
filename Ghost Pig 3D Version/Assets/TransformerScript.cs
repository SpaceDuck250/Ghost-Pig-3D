using UnityEngine;

public class TransformerScript : MonoBehaviour
{
    public TransformerUtilities transformer;
    public TransformableData transformData;

    public GameObject ghostPigObj;



    private void Start()
    {
        if (transformData != null)
        {
            transformer.TransformToSomething(transformData, transformData.transformObject);
        }

        transformer.collisionChecker.OnTransformInto += OnTransformInto;
    }

    private void OnDestroy()
    {
        transformer.collisionChecker.OnTransformInto -= OnTransformInto;
    }

    public void OnTransformInto(TransformableData data, GameObject obj)
    {
        transformer.ClearOldBody();
        transformer.TransformToSomething(data, obj);
        transformer.DestroyOldObject(obj);
    }
}
