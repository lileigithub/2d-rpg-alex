public class PlayerJumpState : PlayerAirState
{

    public PlayerJumpState(Player player, EntityStateMachine<PlayerState> stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        //give y a velocity 
        player.setVelocityAndFacingDir(rb.velocity.x, player.jumpForce);
    }

    public override void Exit()
    {
        base.Exit();
        //attacker.setVelocityAndFacingDir(rb.velocity.x, rb.velocity.y);
    }

    public override void Update()
    {
        base.Update();
        if (rb.velocity.y < 0)
        {
            stateMachine.ChangeState(player.fallState);
        }
    }
}
