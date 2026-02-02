using UnityEngine;

public class DoorAnimatorScript : MonoBehaviour
{
    public DoorScript doorScript;
    public Animator animator;

    private void Start()
    {
        doorScript.OnSelfUnlocked += OnSelfUnlocked;
    }

    private void OnDestroy()
    {
        doorScript.OnSelfUnlocked -= OnSelfUnlocked;
    }

    private void OnSelfUnlocked()
    {
        PlayAnim();
    }

    private void PlayAnim()
    {
        animator.SetBool("Opened", true);
    }
}
