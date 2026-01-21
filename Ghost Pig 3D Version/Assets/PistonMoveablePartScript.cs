using UnityEngine;

public class PistonMoveablePartScript : MonoBehaviour
{
    private Vector3 startPosition;

    public Vector3 displacementVector;

    public float smoothValue;

    public bool buttonPressed;

    private void Start()
    {
        startPosition = transform.position;
        buttonPressed = false;
    }

    private void Update()
    {
        if (!buttonPressed)
        {
            SlowlyMoveToPosition(startPosition);
        }
        else
        {
            Vector3 endPosition = startPosition + displacementVector;
            SlowlyMoveToPosition(endPosition);
        }
    }

    public void SlowlyMoveToPosition(Vector3 destination)
    {
        if (CheckIfReachedDestination(destination))
        {
            return;
        }

        transform.position = Vector3.MoveTowards(transform.position, destination, Time.deltaTime * smoothValue);
        
    }

    private bool CheckIfReachedDestination(Vector3 destination)
    {
        float distanceToDestination = Vector3.Distance(transform.position, destination);

        float closeEnoughValue = 0.01f;

        if (distanceToDestination <= closeEnoughValue)
        {
            return true;
        }

        return false;
    }

    
}
