public class PlayerJumpState : PlayerState
{

    public PlayerJumpState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        //give y a velocity 
        player.setVelocity(rb.velocity.x, player.jumpForce);
    }

    public override void Exit()
    {
        base.Exit();
        player.setVelocity(rb.velocity.x, rb.velocity.y);
    }

    public override void Update()
    {
        base.Update();
        player.setVelocity(xInput * player.moveSpeed * 0.8f, rb.velocity.y, xInput);
        if (rb.velocity.y < 0)
        {
            stateMachine.ChangeState(player.airState);
        }
    }
}
