using UnityEngine;

public class BodyFollowerScript : MonoBehaviour
{
    private GameObject objectBody;
    public BetterTransformUtilities transformUtilities;

    public float smoothValue;

    private void Start()
    {
        TransformerScript.OnTransformBackIntoGhostPig += OnTransformBackIntoGhostPig;
        GhostCollisionChecker.OnTransformInto += OnTransformInto;
    }

    private void OnDestroy()
    {
        TransformerScript.OnTransformBackIntoGhostPig -= OnTransformBackIntoGhostPig;
        GhostCollisionChecker.OnTransformInto -= OnTransformInto;
    }

    private void Update()
    {
        MoveColliderBody();
    }

    private void OnTransformInto(TransformableData data, GameObject obj)
    {
        objectBody = obj;
    }

    private void OnTransformBackIntoGhostPig()
    {
        objectBody = transformUtilities.ghostBody;
    }

    private void MoveColliderBody()
    {
        if (objectBody == null)
        {
            return;
        }

        Vector3 destination = objectBody.transform.position;

        transform.position = Vector3.Lerp(transform.position, destination, Time.deltaTime * smoothValue);
    }
}
