using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField]
    private float _jumpPower = 4;
    private Rigidbody2D Rb { get; set; }
    private bool Grounded { get; set; } = false;
    private bool PrevGrounded { get; set; } = false;
    private bool Jumped { get; set; } = false;

    private void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    /// <summary>
    /// ���������ɐG��Ă��邩�𔻒肷��
    /// </summary>
    /// <returns>�����ɐG��Ă����true�A�����G��Ă��Ȃ����false</returns>
    

    public void Jump()
    {
        if (!Jumped)
        {
            Jumped = true;
            Rb.linearVelocity = new Vector2(Rb.linearVelocity.x, _jumpPower);
            Invoke("EndGtounded", 0.2f);
        }
       
        
    }
    private void EndGtounded()
    {
        Jumped = false;
    }
}
