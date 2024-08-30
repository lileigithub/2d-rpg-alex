using UnityEngine;

public class PlayerState : EntityState
{
    protected Player player;
    protected EntityStateMachine<PlayerState> stateMachine;

    public PlayerState(Player entity, EntityStateMachine<PlayerState> stateMachine, string animBoolName) : base(entity, animBoolName)
    {
        player = entity;
        this.stateMachine = stateMachine;
    }

    public float xInput { get; private set; }
    public float yInput { get; private set; }

    public override void Update()
    {
        base.Update();
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");
        player.animator.SetFloat("yVelocity", rb.velocity.y);
    }

}
