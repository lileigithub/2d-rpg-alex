using UnityEngine;

/**
 * 功能：
 * ->跳。下落时检测到地面，可跳，不必转到idle,以提升流畅度。
 */
public class PlayerFallState : PlayerAirState
{
    public PlayerFallState(Player player, EntityStateMachine<PlayerState> stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
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

        //下落时检测到地面，可跳，不必转到idle,以提升流畅度
        if (player.isGrounded && Input.GetButtonDown("Jump"))
        {
            stateMachine.ChangeState(player.jumpState);
            return;
        }

        if (player.isGrounded || (rb.velocity.x == 0 && rb.velocity.y == 0))
        {
            stateMachine.ChangeState(player.idleState);
            return;
        }

    }
}
