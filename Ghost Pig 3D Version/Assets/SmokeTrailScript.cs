using UnityEngine;

public class SmokeTrailScript : MonoBehaviour
{
    public GameObject smokeTrail;
    public ParticleSystem smokeParticles;
    public ParticleSystem jumpCloudParticles;

    private bool alreadyEmitting = false;

    public Transform player;
    public PlayerMoveScript playerMove;

    private void Start()
    {
        SimpleObjectMove.OnObjectMove += OnObjectMove;
        SimpleObjectMove.OnObjectStopMove += OnObjectStopMoving;

        TransformerScript.OnTransformBackIntoGhostPig += OnTransformBackIntoGhostPig;

        playerMove.OnJump += OnJump;


        SetParticleSystemOn(false, smokeParticles);
    }

    private void OnDestroy()
    {
        SimpleObjectMove.OnObjectMove -= OnObjectMove;
        SimpleObjectMove.OnObjectStopMove -= OnObjectStopMoving;
        TransformerScript.OnTransformBackIntoGhostPig -= OnTransformBackIntoGhostPig;

        playerMove.OnJump -= OnJump;
    }

    private void OnJump()
    {
    }

    private void OnObjectStopMoving()
    {
        SetParticleSystemOn(false, smokeParticles);

    }

    private void OnObjectMove()
    {
        SetParticleSystemOn(true, smokeParticles);

    }

    private void OnTransformBackIntoGhostPig()
    {

        SetParticleSystemOn(false, smokeParticles);
    }

    private void SetParticleSystemOn(bool value, ParticleSystem particleSystem)
    {
        if (value && !alreadyEmitting)
        {
            //smokeTrail.SetActive(true);
            particleSystem.Play();

            alreadyEmitting = true;
        }
        else if (!value)
        {
            //smokeTrail.SetActive(false);
            particleSystem.Stop();

            alreadyEmitting = false;
        }

        //OrientSmokeTrail();

    }
    
}
