using UnityEngine;

public class PlayerState
{
    protected Player player;
    protected PlayerStateMachine stateMachine;
    public string animBoolName { get; private set; }
    protected Rigidbody2D rb;
    public float xInput { get; private set; }
    public float yInput { get; private set; }
    protected float stateTimer;
    //动画结束时的触发器
    protected bool triggerCalled;

    public PlayerState(Player player, PlayerStateMachine stateMachine, string animBoolName)
    {
        this.player = player;
        this.stateMachine = stateMachine;
        this.animBoolName = animBoolName;
        this.rb = player.rb;
    }

    public virtual void Enter()
    {
        player.animator.SetBool(animBoolName, true);
        triggerCalled = false;
    }

    public virtual void Exit()
    {
        player.animator.SetBool(animBoolName, false);
    }
    public virtual void Update()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");
        player.animator.SetFloat("yVelocity", rb.velocity.y);
        stateTimer -= Time.deltaTime;
    }

    public void AnimationFinishTrigger()
    {
        triggerCalled = true;
    }

}
