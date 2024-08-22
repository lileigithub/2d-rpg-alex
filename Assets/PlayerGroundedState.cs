using UnityEngine;

public class PlayerGroundedState : PlayerState
{
    public PlayerGroundedState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
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
        if (Input.GetButtonDown("Jump") && player.isGroundDetected())
        {
            stateMachine.ChangeState(player.jumpState);
            return;
        }
        if (!player.isGroundDetected() && (rb.velocity.y != 0 || rb.velocity.x != 0))
        {
            stateMachine.ChangeState(player.airState);
            return;
        }
    }
}
