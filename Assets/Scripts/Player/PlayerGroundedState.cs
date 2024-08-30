using UnityEngine;
/**
 * 可转移：跳 攻击 下落
 */

public class PlayerGroundedState : PlayerState
{
    public PlayerGroundedState(Player player, EntityStateMachine<PlayerState> stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
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
        //在地面时跳
        if (Input.GetButtonDown("Jump") && player.isGrounded)
        {
            stateMachine.ChangeState(player.jumpState);
            return;
        }
        //地面攻击
        if (Input.GetKeyDown(KeyCode.K))
        {
            stateMachine.ChangeState(player.primaryAttack);
            return;
        }
        //从地面->空中下落
        if (!player.isGrounded && (rb.velocity.y != 0 || rb.velocity.x != 0))
        {
            stateMachine.ChangeState(player.fallState);
            return;
        }
    }
}
