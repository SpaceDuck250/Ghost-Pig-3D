using UnityEngine;

public class NPCAnimator : MonoBehaviour
{
    public PointFollowerScript pointFollower;
    public Animator animator;

    public string pausedVariableName;

    private void Start()
    {
        animator = GetComponent<Animator>();

        pointFollower.OnPauseAtPoint += OnPauseAtPoint;
        pointFollower.OnPointChange += OnPointChange;
    }

    private void OnDestroy()
    {
        pointFollower.OnPauseAtPoint -= OnPauseAtPoint;
        pointFollower.OnPointChange -= OnPointChange;
    }

    private void OnPointChange(Transform obj)
    {
        animator.SetBool(pausedVariableName, false);
    }

    private void OnPauseAtPoint(Transform obj)
    {
        animator.SetBool(pausedVariableName, true);
    }


}
