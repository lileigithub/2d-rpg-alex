public class PlayerWallJumpState : PlayerState
{
    public PlayerWallJumpState(Player player, EntityStateMachine<PlayerState> stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        stateTimer = 0.2f;
        player.setVelocityAndFacingDir(5 * -player.facingDir, player.jumpForce);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if (stateTimer < 0 || player.isGrounded)
        {
            stateMachine.ChangeState(player.fallState);
        }
    }
}
