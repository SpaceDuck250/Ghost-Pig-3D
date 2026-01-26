using UnityEngine;

public class NPCTurnScript : MonoBehaviour
{
    public PointFollowerScript pointFollower;

    private Transform newPoint;
    private bool canRotate = false;

    private void Start()
    {
        pointFollower.OnPauseAtPoint += OnPauseAtPoint;
    }

    private void OnDestroy()
    {
        pointFollower.OnPauseAtPoint -= OnPauseAtPoint;

    }

    private void Update()
    {

        if (newPoint == null)
        {
            newPoint = pointFollower.pathPoints[0];
            return;
        }

        RotateToPoint(newPoint);
    }

    private void OnPauseAtPoint(Transform newPoint)
    {
        this.newPoint = newPoint;
        //canRotate = true;
    }

    private void RotateToPoint(Transform point)
    {
        float rotationSpeed = 180;


        Vector3 angleVector = (point.position - transform.position).normalized;

        float turnAngle = Mathf.Atan2(angleVector.x, angleVector.z) * Mathf.Rad2Deg;

        //float rotateAngle = Mathf.Lerp(transform.rotation.y, turnAngle, rotationSpeed * Time.deltaTime);

        Quaternion qAngle = Quaternion.Euler(0, turnAngle, 0);



        //transform.rotation = qAngle;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, qAngle, rotationSpeed * Time.deltaTime);
    }
}
