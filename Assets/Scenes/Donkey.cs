using UnityEngine;

public class Donkey : MonoBehaviour
{
    public LayerMask rightGroundLayer; // RightGround Layer��Inspector�Őݒ�
    public LayerMask leftGroundLayer;  // LeftGround Layer��Inspector�Őݒ�
    public Transform groundCheckPoint; // �n�ʔ���p�̃|�C���g
    public float moveSpeed = 2f;       // 移動速度
    private bool rightGround = false;
    private bool leftGround = false;
    private Rigidbody2D rb;
    
    public float checkRadius = 1f;   // ���蔼�a

    Player player;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        player = FindObjectOfType<Player>();
        
    }

    void Update()
    {
        if (!groundCheckPoint)
        {
            GetComponent<Rigidbody2D>().linearVelocity = Vector3.zero;
        }
        
        CheckGround();
        MoveBasedOnSlope();
    }
    
    void CheckGround()
    {
        // RightGround�̔���
        rightGround = Physics2D.OverlapCircle(groundCheckPoint.position, checkRadius, rightGroundLayer);
        // LeftGround�̔���
        leftGround = Physics2D.OverlapCircle(groundCheckPoint.position, checkRadius, leftGroundLayer);
    }
    void MoveBasedOnSlope()
    {
        if (rightGround)
        {

            // �E�X���n�ʂɂ��� �� �E�Ɉړ�
            //rb.linearVelocity = new Vector3(moveSpeed, rb.linearVelocity.y);
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        }
        else if (leftGround)
        {

            // ���X���n�ʂɂ��� �� ���Ɉړ�
            //rb.linearVelocity = new Vector3(-moveSpeed, rb.linearVelocity.y);
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        }
        else
        {
            // �n�ʂȂ��Ȃ�~�߂�i�����͎��R�����j
            rb.linearVelocity = new Vector3(0, rb.linearVelocity.y);
        }
        
    }
}
