using UnityEngine;

public class WalkZoneScript : MonoBehaviour
{

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag != "Player")
        {
            return;
        }

        Vector3 enterVector = (other.transform.position - transform.position).normalized;

        if (ExitedFromBack(enterVector))
        {
            LevelManager.instance.TeleportPlayerToNextLevel();
        }

        print("exited");
    }

    public bool ExitedFromBack(Vector3 enterDirection)
    {
        float dotproduct = Vector3.Dot(enterDirection, -transform.forward);
        if (dotproduct > 0)
        {
            return true;
        }

        return false;
    }


}
