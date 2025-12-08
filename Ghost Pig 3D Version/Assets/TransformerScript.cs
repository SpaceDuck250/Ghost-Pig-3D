using UnityEngine;
using System;

public class TransformerScript : MonoBehaviour
{
    public TransformerUtilities transformer;

    public TransformableData ghostPigData;

    public static System.Action OnTransformBackIntoGhostPig;

    private void Start()
    {
        TransformBackIntoGhostPig();

        transformer.collisionChecker.OnTransformInto += OnTransformIntoObject;
    }

    private void OnDestroy()
    {
        transformer.collisionChecker.OnTransformInto -= OnTransformIntoObject;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            TransformBackIntoGhostPig(); 
        }
    }

    public void OnTransformIntoObject(TransformableData data, GameObject obj)
    {
        Vector3 blockPosition = obj.transform.position;

        transformer.TransformToSomething(data, obj, blockPosition);
        transformer.DestroyOldObject(obj);
    }

    public void TransformBackIntoGhostPig()
    {
        TransformableData currentTransformableData = transformer.currentTransformData;

        if (currentTransformableData != null)
        {
            GameObject currentObj = currentTransformableData.transformObject;
            transformer.CreateOldObject(currentObj);

        }

        transformer.TransformToSomething(ghostPigData, ghostPigData.transformObject, transform.position);

        OnTransformBackIntoGhostPig?.Invoke();
    }
}
