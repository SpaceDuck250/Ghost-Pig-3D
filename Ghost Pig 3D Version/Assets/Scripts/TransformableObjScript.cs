using UnityEngine;

public class TransformableObjScript : MonoBehaviour
{
    private void Start()
    {
        gameObject.layer = LayerMask.NameToLayer("Objects");
    }

    public TransformableData transformableData;
}
