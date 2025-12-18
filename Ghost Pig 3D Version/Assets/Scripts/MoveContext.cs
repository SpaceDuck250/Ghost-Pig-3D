using UnityEngine;

public class MoveContext : MonoBehaviour
{
    public Rigidbody rb;
    public Camera cam;
    public GameObject player;
    public GroundCheckerScript groundCheckScript;

    public MoveContext(Rigidbody rb, Camera cam, GameObject player, GroundCheckerScript groundCheckScript)
    {
        this.rb = rb;
        this.cam = cam;
        this.player = player;
        this.groundCheckScript = groundCheckScript;
    }
}
