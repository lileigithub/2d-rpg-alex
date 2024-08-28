using UnityEngine;

public class Player : Entity
{
    #region States
    public PlayerStateMachine stateMachine { get; private set; }
    public PlayerState moveState { get; private set; }
    public PlayerState idleState { get; private set; }
    public PlayerFallState fallState { get; private set; }
    public PlayerJumpState jumpState { get; private set; }
    public PlayerDashState dashState { get; private set; }
    public PlayerWallSlideState wallSlideStatte { get; private set; }
    public PlayerWallJumpState wallJumpState { get; private set; }
    public PlayerPrimaryAttack primaryAttack { get; private set; }
    #endregion

    #region Move info
    [Header("Move info")]
    public float jumpForce = 8f;
    public float xInput;
    public float dashSpeed = 8f;
    public float dashDuration = 0.4f;
    public float dashDir;
    [SerializeField] private float dashCoolDownTime = 1f;
    [SerializeField] private float dashUsageTimer;
    #endregion

    #region Attack info
    [Header("Attack info")]
    //攻击时的小位移
    public Vector2[] attackMovements;
    #endregion

    protected override void Awake()
    {
        base.Awake();
        stateMachine = new PlayerStateMachine();
        moveState = new PlayerMoveState(this, stateMachine, "Move");
        idleState = new PlayerIdleState(this, stateMachine, "Idle");
        fallState = new PlayerFallState(this, stateMachine, "Jump");
        jumpState = new PlayerJumpState(this, stateMachine, "Jump");
        dashState = new PlayerDashState(this, stateMachine, "Dash");
        wallSlideStatte = new PlayerWallSlideState(this, stateMachine, "WallSlide");
        wallJumpState = new PlayerWallJumpState(this, stateMachine, "Jump");
        primaryAttack = new PlayerPrimaryAttack(this, stateMachine, "Attack");
    }
    // Enter is called before the first frame update
    protected override void Start()
    {
        base.Start();
        stateMachine.Initialize(idleState);
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
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

    public void AnimationTrigger() => stateMachine.currectState.AnimationFinishTrigger();
}
