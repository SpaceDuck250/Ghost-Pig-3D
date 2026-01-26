using UnityEngine;
using System.Collections.Generic;
using System;
using System.Collections;

public class PointFollowerScript : MonoBehaviour 
{
    // npc could never reach the point if a box was on it and also things would be unbaked
    public List<Transform> pathPoints = new List<Transform>();

    public event Action<Transform> OnPointChange;
    public event Action<Transform> OnPauseAtPoint;

    public float pauseTime;
    private bool paused = false;

    [SerializeField]
    public int currentPointIndex = 0;

    private void Start()
    {
        StartCoroutine(PauseBeforeGoingToNewPoint(pauseTime));

    }

    private void Update()
    {
        TryToGoToTheNextPoint();
    }

    private void TryToGoToTheNextPoint()
    {
        if (!CheckIfPointHasBeenReached() || paused)
        {
            return;
        }

        currentPointIndex++;
        if (currentPointIndex >= pathPoints.Count)
        {
            currentPointIndex = 0;
        }

        StartCoroutine(PauseBeforeGoingToNewPoint(pauseTime));
    }

    private bool CheckIfPointHasBeenReached()
    {
        float distance = Vector3.Distance(transform.position, pathPoints[currentPointIndex].position);

        float closeEnough = 0.7f;
        if (distance < closeEnough)
        {
            return true;
        }

        return false;
    }

    private IEnumerator PauseBeforeGoingToNewPoint(float pauseTime)
    {
        paused = true;

        Transform newPoint = pathPoints[currentPointIndex];
        OnPauseAtPoint?.Invoke(newPoint);

        yield return new WaitForSeconds(pauseTime);

        OnPointChange?.Invoke(newPoint);

        paused = false;
    }
}
