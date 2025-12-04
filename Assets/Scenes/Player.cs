using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    public float moveSpeed = 1.0f;//Playeｒのスピード
    public float jumpForce = 10f;    // ジャンプ力
    private float speed = 5.0f;//はしごの上る速さ
    private bool isGrounded;         // 地面に接しているかどうか
    [SerializeField] private LayerMask ladderLayer;//��q�����邩�ǂ����̔�������邽��
    private float gravity;//���̏d��
    private float inputY;
    [Header("地面チェック")]
    public Transform groundCheck;    // 地面チェック用の位置
    public float groundRadius = 0.8f; // 地面判定の円の半径
    
    public LayerMask groundLayer;    // 地面レイヤー
    public LayerMask groundLayer2;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }
    private void Move()
    {
        inputY = Input.GetAxisRaw("Vertical");
        float moveInput = 0;
        if (Input.GetKey(KeyCode.D))
        {
            moveInput = 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveInput = -1;
        }
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        if (Ladder())
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, inputY * speed);
        }
    }
    private void Jump()
    {
        // 地面チェック
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundLayer);
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundLayer2);

        // スペースキーでジャンプ
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {     
            //animator.SetBool("Jump", false);
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

        private bool Ladder()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.5f, ladderLayer);
        if(hit.collider != null)
        return true;
        else
            return false;
        
    }

}
