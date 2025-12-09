using UnityEngine;
using System;
using System.Collections.Generic;

public class GhostCollisionChecker : MonoBehaviour
{
    public event Action<TransformableData, GameObject> OnTransformInto;
    public static Action<GameObject> OnObjectEnter;

    public GhostCollisionListScript collisionListScript;

    [SerializeField]
    private GameObject selectedObject;

    private bool ghostCollisionDisabled = false;

    private void Start()
    {
        collisionListScript.enteredObjectList.Clear();

        TransformerScript.OnTransformBackIntoGhostPig += OnTransformBackIntoGhostPig;
    }

    private void OnDestroy()
    {
        TransformerScript.OnTransformBackIntoGhostPig -= OnTransformBackIntoGhostPig;

    }

    private void Update()
    {
        TrySelectingNewObject();

        if (Input.GetKeyDown(KeyCode.Q) && selectedObject != null)
        {
            TransformInto(selectedObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (ghostCollisionDisabled)
        {
            return;
        }

        collisionListScript.TryAddObjectToList(other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        if (ghostCollisionDisabled)
        {
            return;
        }

        collisionListScript.RemoveObjectFromList(other.gameObject);
        selectedObject = null;
    }

    private void OnTransformBackIntoGhostPig()
    {
        ghostCollisionDisabled = false;
        selectedObject = null;
    }

    private void TransformInto(GameObject obj)
    {
        TransformableObjScript transformableScript = obj.GetComponent<TransformableObjScript>();
        if (transformableScript == null)
        {
            return;
        }

        TransformableData data = transformableScript.transformableData;

        if (data != null) // change later
        {
            ghostCollisionDisabled = true;

            OnTransformInto?.Invoke(data, selectedObject);

            collisionListScript.ClearObjectsFromList();

            selectedObject = null;
        }
    }

    private GameObject FindClosestObject(List<GameObject> objectList)
    {
        if (objectList == null)
        {
            return null;
        }

        float minDistance = float.MaxValue;
        GameObject closestObject = null;

        foreach (GameObject obj in objectList)
        {
            float distance = Vector3.Distance(transform.position, obj.transform.position);
            if (distance < minDistance)
            {
                closestObject = obj;
            }
        }

        return closestObject;
    }

    private void TrySelectingNewObject()
    {
        if (collisionListScript.enteredObjectList.Count == 0 || ghostCollisionDisabled)
        {
            return;
        }

        selectedObject = FindClosestObject(collisionListScript.enteredObjectList);
        OnObjectEnter?.Invoke(selectedObject);
    }
}
