using UnityEngine;

public class Entity : MonoBehaviour
{
    #region Components
    public Animator animator { get; private set; }
    public Rigidbody2D rb { get; private set; }

    #endregion

    #region Collision info
    [Header("Collision info")]
    [SerializeField] protected Transform groundCheck;
    [SerializeField] protected float groundCheckDistance = 0.2f;
    [SerializeField] protected LayerMask groundLayerMask;
    [SerializeField] protected Transform wallCheck;
    [SerializeField] protected float wallCheckDistance = 0.2f;
    [SerializeField] protected LayerMask wallLayerMask;
    #endregion

    #region Move info
    public float moveSpeed = 5f;
    public int facingDir { get; private set; } = 1;
    public bool isFacingRight { get; private set; } = true;
    [SerializeField] public bool isGrounded;
    [SerializeField] public bool isWall;
    #endregion

    protected virtual void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    protected virtual void Start()
    {

    }

    // Update is called once per frame
    protected virtual void Update()
    {
        isGrounded = Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, groundLayerMask);
        isWall = Physics2D.Raycast(wallCheck.position, Vector2.right, wallCheckDistance * facingDir, wallLayerMask);
    }


    public void Flip()
    {
        facingDir *= -1;
        isFacingRight = !isFacingRight;
        rb.transform.Rotate(0, 180, 0);
    }

    private void FlipController(float x)
    {
        if ((x > 0 && !isFacingRight) || (x < 0 && isFacingRight))
            Flip();
    }

    public void setVelocity(float x, float y, float facingDir)
    {
        rb.velocity = new Vector2(x, y);
        if (facingDir == 0) facingDir = x;
        FlipController(facingDir);
    }

    public void setVelocity(float x, float y)
    {
        rb.velocity = new Vector2(x, y);
        FlipController(x);
    }

    protected virtual void OnDrawGizmos()
    {
        //draw ground check line
        Gizmos.DrawLine(groundCheck.position, new Vector2(groundCheck.position.x, groundCheck.position.y - groundCheckDistance));
        Gizmos.DrawLine(wallCheck.position, new Vector2(wallCheck.position.x + wallCheckDistance * facingDir, wallCheck.position.y));
    }
}
