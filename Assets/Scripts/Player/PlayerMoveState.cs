/**
 * ¿É×ªÒÆ£ºÌø ¹¥»÷ ÏÂÂä idle
 */
public class PlayerMoveState : PlayerGroundedState
{
    public PlayerMoveState(Player player, EntityStateMachine<PlayerState> stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        player.setVelocityAndFacingDir(xInput * player.moveSpeed, rb.velocity.y);
        if (xInput == 0 && player.isGrounded)
        {
            stateMachine.ChangeState(player.idleState);
        }
    }


}
