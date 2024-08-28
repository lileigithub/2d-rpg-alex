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
        //�����ƶ�ͬʱ����ʱ��������
        if (xInput != 0 && player.isGrounded && !Input.GetButtonDown("Jump"))
        {
            stateMachine.ChangeState(player.moveState);
            return;
        }
    }
}
