/**
 * 功能：在空中的位移输入稍微减速
 * -> 滑墙
 */
public class PlayerAirState : PlayerState
{
    public PlayerAirState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
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
        //在空中的位移输入稍微减速
        player.setVelocity(xInput * player.moveSpeed * 0.8f, rb.velocity.y, xInput);
        //使跳和下落时碰到墙，都可滑墙
        if (player.isWall && !player.isGrounded)
        {
            stateMachine.ChangeState(player.wallSlideStatte);
            return;
        }
    }
}
