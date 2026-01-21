using UnityEngine;
using UnityEngine.Rendering;

public class GhostTransformEffect : MonoBehaviour
{
    public Volume effectsVolume;

    private void Start()
    {

        GhostCollisionChecker.OnTransformInto += OnTransformInto;
    }

    private void OnDestroy()
    {
        GhostCollisionChecker.OnTransformInto -= OnTransformInto;

    }
    private void OnTransformInto(TransformableData data, GameObject obj)
    {

        
    }

    private void SetOff()
    {

    }
}
