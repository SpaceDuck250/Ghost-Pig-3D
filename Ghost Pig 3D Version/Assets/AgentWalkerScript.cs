using UnityEngine;
using UnityEngine.AI;

public class AgentWalkerScript : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform target;

    public PointFollowerScript pointFollower;

    private void Awake()
    {
        pointFollower.OnPointChange += OnPointChange;
    }

    private void Start()
    {
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        

    }

    private void OnDestroy()
    {
        pointFollower.OnPointChange -= OnPointChange;

    }
    private void OnPointChange(Transform newPoint)
    {
        TravelToPoint(newPoint.position);
    }

    public void TravelToPoint(Vector3 newPosition)
    {
        agent.SetDestination(newPosition);
    }
}
