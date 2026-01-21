using UnityEngine;

public class BetterTransformingScript : MonoBehaviour
{
    public BetterTransformUtilities transformUtilities;

    private void Start()
    {
        GhostCollisionChecker.OnTransformInto += OnTransformInto;

        TransformBackIntoGhostPig();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            TransformBackIntoGhostPig();
        }
    }

    private void OnDestroy()
    {
        GhostCollisionChecker.OnTransformInto -= OnTransformInto;
    }

    private void OnTransformInto(TransformableData transformData, GameObject transformObject)
    {
        transformUtilities.TransformIntoSomething(transformObject);
    }

    private void TransformBackIntoGhostPig()
    {
        if (transformUtilities.alreadyGhostPig)
        {
            return;
        }

        GameObject ghostPigBody = transformUtilities.ghostBody;
        transformUtilities.TransformIntoSomething(ghostPigBody);

        TransformerScript.OnTransformBackIntoGhostPig?.Invoke();
    }


}
