using UnityEngine;

public class DoorCollisionScript : MonoBehaviour
{
    [SerializeField]
    private bool unlocked = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (!CheckIfKey(collision.gameObject) || unlocked)
        {
            return;
        }

        unlocked = true;
        DoorScript doorScript = GetComponent<DoorScript>();
        doorScript.IncrementDoorCount();
    }

    private bool CheckIfKey(GameObject obj)
    {
        TransformerUtilities transformScript = obj.GetComponent<TransformerUtilities>();
        if (transformScript != null)
        {
            string objectTag = transformScript.playerBody.tag;
            bool isKey = objectTag == "Key" ? true : false;

            return isKey;
        }

        return false;
    }
}
