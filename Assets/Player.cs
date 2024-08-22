using UnityEngine;

public class Player : MonoBehaviour
{
    #region Components
    public Animator animator { get; private set; }
    public Rigidbody2D rb { get; private set; }

    #endregion

    #region States
    public PlayerStateMachine stateMachine { get; private set; }
    public PlayerState moveState { get; private set; }
    public PlayerState idleState { get; private set; }
    public PlayerAirState airState { get; private set; }
    public PlayerJumpState jumpState { get; private set; }
    public PlayerDashState dashState { get; private set; }
    public PlayerWallSlideState wallSlideStatte { get; private set; }
    public PlayerWallJumpState wallJumpState { get; private set; }
    #endregion

    [Header("Move info")]
    public float moveSpeed = 5f;
    public float jumpForce = 8f;
    public bool isGrounded;
    public float xInput;

    public float dashSpeed = 8f;
    public float dashDuration = 0.4f;
    public float dashDir;
    [SerializeField] private float dashCoolDownTime = 1f;
    [SerializeField] private float dashUsageTimer;
    public int facingDir { get; private set; } = 1;
    public bool isFacingRight { get; private set; } = true;

    [Header("Collision info")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckDistance = 0.2f;
    [SerializeField] private LayerMask groundLayerMask;

    [SerializeField] private Transform wallCheck;
    [SerializeField] private float wallCheckDistance = 0.2f;
    [SerializeField] private LayerMask wallLayerMask;



    private void Awake()
    {
        stateMachine = new PlayerStateMachine();
        animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();

        moveState = new PlayerMoveState(this, stateMachine, "Move");
        idleState = new PlayerIdleState(this, stateMachine, "Idle");
        airState = new PlayerAirState(this, stateMachine, "Jump");
        jumpState = new PlayerJumpState(this, stateMachine, "Jump");
        dashState = new PlayerDashState(this, stateMachine, "Dash");
        wallSlideStatte = new PlayerWallSlideState(this, stateMachine, "WallSlide");
        wallJumpState = new PlayerWallJumpState(this, stateMachine, "Jump");
    }
    // Enter is called before the first frame update
    void Start()
    {
        stateMachine.Initialize(idleState);
    }

    // Update is called once per frame
    void Update()
    {
        stateMachine.currectState.Update();
        xInput = stateMachine.currectState.xInput;
        CheckForDashInput();
    }

    private void CheckForDashInput()
    {
        dashUsageTimer -= Time.deltaTime;
        if (Input.GetButtonDown("Fire3") && dashUsageTimer < 0)
        {
            dashUsageTimer = dashCoolDownTime;
            dashDir = Input.GetAxisRaw("Horizontal");
            if (dashDir == 0) dashDir = facingDir;
            stateMachine.ChangeState(dashState);
        }
    }

    private void OnDrawGizmos()
    {
        //draw ground check line
        Gizmos.DrawLine(groundCheck.position, new Vector2(groundCheck.position.x, groundCheck.position.y - groundCheckDistance));
        Gizmos.DrawLine(wallCheck.position, new Vector2(wallCheck.position.x + wallCheckDistance * facingDir, wallCheck.position.y));
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

    public bool isGroundDetected()
    {
        isGrounded = Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, groundLayerMask);
        return isGrounded;
    }
    public bool isWallDetected() => Physics2D.Raycast(wallCheck.position, Vector2.right, wallCheckDistance * facingDir, wallLayerMask);

    public void Flip()
    {
        facingDir *= -1;
        isFacingRight = !isFacingRight;
        rb.transform.Rotate(0, 180, 0);
    }

    public void FlipController(float x)
    {
        if ((x > 0 && !isFacingRight) || (x < 0 && isFacingRight))
            Flip();
    }
}
