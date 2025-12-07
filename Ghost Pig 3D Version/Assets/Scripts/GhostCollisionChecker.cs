using UnityEngine;
using System;
using System.Collections.Generic;

public class GhostCollisionChecker : MonoBehaviour
{
    public event Action<TransformableData> OnTransformInto;
    public event Action<GameObject> OnObjectEnter;

    public GameObject selectedObject;

    public List<GameObject> enteredObjectList = new List<GameObject>();

    public static GhostCollisionChecker instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        enteredObjectList.Clear();
    }

    private void Update()
    {
        TrySelectingNewObject();
    }

    private void OnTriggerEnter(Collider other)
    {
        TryAddObjectToList(other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
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
            OnTransformInto?.Invoke(data);
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
        print("a");
    
    }

}
