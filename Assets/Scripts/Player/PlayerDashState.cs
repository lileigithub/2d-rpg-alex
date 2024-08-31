
public class PlayerDashState : PlayerState
{
    public PlayerDashState(Player player, EntityStateMachine<PlayerState> stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        stateTimer = player.dashDuration;
        SkillManager.instance.cloneSkill.CreateClone(player.transform);
    }

    public override void Exit()
    {
        base.Exit();
        player.setVelocityAndFacingDir(0, rb.velocity.y);
    }

    public override void Update()
    {
        base.Update();
        if (stateTimer < 0)
        {
            stateMachine.ChangeState(player.idleState);
        }
        else if (stateTimer > 0)
        {
            player.setVelocityAndFacingDir(player.dashSpeed * player.dashDir, 0);
        }
    }
}
