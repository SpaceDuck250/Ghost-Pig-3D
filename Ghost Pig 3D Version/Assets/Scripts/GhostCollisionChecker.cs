using UnityEngine;
using System;
using System.Collections.Generic;

public class GhostCollisionChecker : MonoBehaviour
{
    public event Action<TransformableData, GameObject> OnTransformInto;
    public static event Action<GameObject> OnObjectEnter;

    [SerializeField]
    private GameObject selectedObject;

    [SerializeField]
    private List<GameObject> enteredObjectList = new List<GameObject>();

    private bool ghostCollisionDisabled = false;

    private void Start()
    {
        enteredObjectList.Clear();
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

        TryAddObjectToList(other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        if (ghostCollisionDisabled)
        {
            return;
        }

        RemoveObjectFromList(other.gameObject);
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
            OnTransformInto?.Invoke(data, selectedObject);
            enteredObjectList.Remove(obj);

            ghostCollisionDisabled = true;
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

    private void TryAddObjectToList(GameObject obj)
    {
        TransformableObjScript transformableScript = obj.GetComponent<TransformableObjScript>();
        if (transformableScript == null)
        {
            return;
        }

        if (!enteredObjectList.Contains(obj))
        {
            enteredObjectList.Add(obj);
        }
    }

    private void RemoveObjectFromList(GameObject obj)
    {
        enteredObjectList.Remove(obj);
        if (enteredObjectList.Count == 0)
        {
            OnObjectEnter?.Invoke(null);
        }

    }

    private void TrySelectingNewObject()
    {
        if (enteredObjectList.Count == 0)
        {
            return;
        }

        selectedObject = FindClosestObject(enteredObjectList);
        OnObjectEnter?.Invoke(selectedObject);
    }



}
