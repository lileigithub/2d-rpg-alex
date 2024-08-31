/**
 * ���ܣ��ڿ��е�λ��������΢����
 * -> ��ǽ
 */
public class PlayerAirState : PlayerState
{
    public PlayerAirState(Player player, EntityStateMachine<PlayerState> stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
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
        //�ڿ��е�λ��������΢����
        player.setVelocityAndFacingDir(xInput * player.moveSpeed * 0.8f, rb.velocity.y, xInput);
        //ʹ��������ʱ����ǽ�����ɻ�ǽ
        if (player.isWall && !player.isGrounded)
        {
            stateMachine.ChangeState(player.wallSlideStatte);
            return;
        }
    }
}
