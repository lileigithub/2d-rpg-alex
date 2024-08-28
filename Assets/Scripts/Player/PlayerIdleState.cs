using UnityEngine;

public class PlayerIdleState : PlayerGroundedState
{
    public PlayerIdleState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
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
        //跳和移动同时触发时，优先跳
        if (xInput != 0 && player.isGrounded && !Input.GetButtonDown("Jump"))
        {
            stateMachine.ChangeState(player.moveState);
            return;
        }
    }
}
