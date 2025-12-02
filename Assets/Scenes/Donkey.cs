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


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
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
            rb.linearVelocity = new Vector2(moveSpeed, rb.linearVelocity.y);
        }
        else if (leftGround)
        {
            // ���X���n�ʂɂ��� �� ���Ɉړ�
            rb.linearVelocity = new Vector2(-moveSpeed, rb.linearVelocity.y);
        }
        else
        {
            // �n�ʂȂ��Ȃ�~�߂�i�����͎��R�����j
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
        }
    }
}
