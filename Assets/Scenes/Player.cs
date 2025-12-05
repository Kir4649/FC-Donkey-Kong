using UnityEngine;
using UnityEngine.U2D;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    public float moveSpeed = 1.0f;//Playeｒのスピード
    public float speed = 5.0f;//はしごの上る速さ
    private SpriteRenderer sprite;
    [SerializeField] private LayerMask ladderLayer;//��q�����邩�ǂ����̔�������邽��
    private float gravity;//���̏d��
    private float inputY;
    [Header("地面チェック")]
    private bool isGround = false;
    public float jumpForce = 10f;    // ジャンプ力
    private bool Grounded { get; set; } = false;
    private bool PrevGrounded { get; set; } = false;
    private bool Jumped { get; set; } = false;
    public float PlayerHP = 1;
    public GameObject End;

    Enemy enemy;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        enemy = FindObjectOfType<Enemy>();
        if (End != null) End.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        if(PlayerHP < 0)
        {
             
            if (End != null) End.SetActive(true);
            
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            PlayerHP = -1;
        }
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

        if (moveInput > 0) sprite.flipX = false;
        else if (moveInput < 0) sprite.flipX = true;

        if (Ladder())
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, inputY * speed);
        }
    }
    public void Jump()
    {
        if (!Jumped)
        {
            Jumped = true;
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            Invoke("EndGtounded", 1f);
        }
    }
    private void EndGtounded()
    {
        Jumped = false;
    }

    private bool Ladder()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.5f, ladderLayer);
        if (hit.collider != null)
            return true;
        else
            return false;

    }

}
