using UnityEngine;
using System.Collections.Generic;

public class GhostCollisionListScript : MonoBehaviour
{
    public List<GameObject> enteredObjectList = new List<GameObject>();

    public GhostCollisionChecker collisionChecker;


    public void TryAddObjectToList(GameObject obj)
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

    public void RemoveObjectFromList(GameObject obj)
    {
        enteredObjectList.Remove(obj);
        if (enteredObjectList.Count == 0)
        {

            GhostCollisionChecker.OnObjectEnter?.Invoke(null);
        }

    }

    public void ClearObjectsFromList()
    {
        enteredObjectList.Clear();
    }

}
