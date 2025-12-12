using UnityEngine;
using System;

public class TransformerScript : MonoBehaviour
{
    public TransformerUtilities transformer;

    public TransformableData ghostPigData;

    public static System.Action OnTransformBackIntoGhostPig;

    private bool alreadyGhostPig;

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

        alreadyGhostPig = false;
    }

    public void TransformBackIntoGhostPig()
    {
        if (alreadyGhostPig)
        {
            return;
        }

        TransformableData currentTransformableData = transformer.currentTransformData;

        if (currentTransformableData != null)
        {
            GameObject currentObj = currentTransformableData.transformObject;
            Quaternion objectRotation = transformer.playerBody == null ? Quaternion.identity : transformer.playerBody.transform.rotation;

            transformer.CreateOldObject(currentObj, objectRotation);

        }

        transformer.TransformToSomething(ghostPigData, ghostPigData.transformObject, transform.position);

        alreadyGhostPig = true;

        OnTransformBackIntoGhostPig?.Invoke();
    }
}
