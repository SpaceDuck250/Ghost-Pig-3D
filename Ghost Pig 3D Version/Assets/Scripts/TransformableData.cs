using UnityEngine;

[CreateAssetMenu(fileName = "TransformableData", menuName = "Scriptable Objects/TransformableData")]
public class TransformableData : ScriptableObject
{
    public GameObject transformObject;

    public float moveSpeed;
    public float smoothValue;
    public float jumpForce;

    public GameObject moveComponentObj;
    public bool useGravity = true;

    public Vector3 groundCheckPositionOffset;
}
