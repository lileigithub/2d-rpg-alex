using UnityEngine;

public class Player : Entity
{
    #region States

    public PlayerState moveState { get; private set; }
    public PlayerState idleState { get; private set; }
    public PlayerFallState fallState { get; private set; }
    public PlayerJumpState jumpState { get; private set; }
    public PlayerDashState dashState { get; private set; }
    public PlayerWallSlideState wallSlideStatte { get; private set; }
    public PlayerWallJumpState wallJumpState { get; private set; }
    public PlayerPrimaryAttack primaryAttack { get; private set; }
    public PlayerCounterAttackState counterAttackState { get; private set; }
    #endregion

    #region Move info
    [Header("Move info")]
    public float jumpForce = 8f;
    public float xInput;
    public float dashSpeed = 8f;
    public float dashDuration = 0.4f;
    public float dashDir;
    #endregion

    #region Attack info
    [Header("Attack info")]
    //攻击时的小位移
    public Vector2[] attackMovements;
    public float counterAttackDuration = 0.2f;
    #endregion

    protected EntityStateMachine<PlayerState> stateMachine { get; set; }

    protected override void Awake()
    {
        base.Awake();
        stateMachine = new EntityStateMachine<PlayerState>();
        moveState = new PlayerMoveState(this, stateMachine, "Move");
        idleState = new PlayerIdleState(this, stateMachine, "Idle");
        fallState = new PlayerFallState(this, stateMachine, "Jump");
        jumpState = new PlayerJumpState(this, stateMachine, "Jump");
        dashState = new PlayerDashState(this, stateMachine, "Dash");
        wallSlideStatte = new PlayerWallSlideState(this, stateMachine, "WallSlide");
        wallJumpState = new PlayerWallJumpState(this, stateMachine, "Jump");
        primaryAttack = new PlayerPrimaryAttack(this, stateMachine, "Attack");
        counterAttackState = new PlayerCounterAttackState(this, stateMachine, "CounterAttack");
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
        if (Input.GetButtonDown("Fire3") && SkillManager.instance.dashSkill.CanAndUseSkill())
        {
            dashDir = Input.GetAxisRaw("Horizontal");
            if (dashDir == 0) dashDir = facingDir;
            stateMachine.ChangeState(dashState);
        }
    }

    public void AnimationTrigger()
    {
        if (stateMachine.currectState != null)
            stateMachine.currectState.AnimationFinishTrigger();
    }

}
