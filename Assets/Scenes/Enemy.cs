using UnityEngine;

public class Enemy : MonoBehaviour
{
    public LayerMask rightGroundLayer; // RightGround Layer??Inspector????
    public LayerMask leftGroundLayer;  // LeftGround Layer??Inspector????
    [Header("ˆÚ“®‘¬“x")] public float speed;
    [Header("d—Í")] public float gravity;
    private Rigidbody2D rb;
    private bool rightGround = false;
    private bool leftGround = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       
      
    }
}
