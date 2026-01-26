using UnityEngine;

public class SFXPlayerScript : MonoBehaviour
{
    private SoundManagerScript soundManager;
    private SfxStorerScript sfxStorage;
    public PlayerMoveScript playerMove;

    private void Start()
    {
        if (DontDestroyScript.instance == null)
        {
            return;
        }

        soundManager = DontDestroyScript.instance.transform.Find("SoundManager").GetComponent<SoundManagerScript>();

        sfxStorage = soundManager.sfxStorage;

        TransformerScript.OnTransformBackIntoGhostPig += OnTransformBackIntoGhostPig;
        GhostCollisionChecker.OnTransformInto += OnTransformInto;
        playerMove.OnJump += OnJump;

        SimpleObjectMove.OnObjectMove += OnObjectMove;
        SimpleObjectMove.OnObjectStopMove += OnObjectStopMove;

        ButtonScript.OnButtonFirstTimeClicked += OnButtonClicked;
    }

    private void OnDestroy()
    {
        TransformerScript.OnTransformBackIntoGhostPig -= OnTransformBackIntoGhostPig;
        GhostCollisionChecker.OnTransformInto -= OnTransformInto;
        playerMove.OnJump -= OnJump;

        SimpleObjectMove.OnObjectMove -= OnObjectMove;
        SimpleObjectMove.OnObjectStopMove -= OnObjectStopMove;

    }

    private void OnTransformInto(TransformableData data, GameObject obj)
    {
        AudioClip transformSFX = sfxStorage.transformSFX;
        soundManager.PlayEffect(transformSFX, false);
    }

    private void OnTransformBackIntoGhostPig()
    {
        AudioClip transformSFX = sfxStorage.transformSFX;
        soundManager.PlayEffect(transformSFX, false);
        soundManager.PlayFootsteps(false);
    }

    private void OnJump()
    {
        AudioClip jumpSFX = sfxStorage.jumpSFX;
        soundManager.PlayEffect(jumpSFX, false);
    }

    private void OnObjectStopMove()
    {
        soundManager.PlayFootsteps(false);
    }

    private void OnObjectMove()
    {
        soundManager.PlayFootsteps(true);
    }

    private void OnButtonClicked()
    {
        AudioClip buttonPressSFX = sfxStorage.buttonClickSFX;
        soundManager.PlayEffect(buttonPressSFX, false);
    }

}
