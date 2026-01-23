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
        // UNCOMMENT TO REVERT TO OLD SYSTEM
        //TransformerUtilities transformScript = obj.GetComponent<TransformerUtilities>();

        TransformableObjScript transformScript = obj.GetComponent<TransformableObjScript>();

        print(transformScript + " iifoodosg");

        if (transformScript != null)
        {
            string objectTag = transformScript.gameObject.tag;

            //string objectTag = transformScript.name;
            bool isKey = objectTag == "Key" ? true : false;

            return isKey;
        }

        return false;
    }
}
