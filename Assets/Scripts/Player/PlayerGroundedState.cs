using UnityEngine;
/**
 * ��ת�ƣ��� ���� ����
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
        //�ڵ���ʱ��
        if (Input.GetButtonDown("Jump") && player.isGrounded)
        {
            stateMachine.ChangeState(player.jumpState);
            return;
        }
        //���湥��
        if (Input.GetKeyDown(KeyCode.K))
        {
            stateMachine.ChangeState(player.primaryAttack);
            return;
        }
        //�ӵ���->��������
        if (!player.isGrounded && (rb.velocity.y != 0 || rb.velocity.x != 0))
        {
            stateMachine.ChangeState(player.fallState);
            return;
        }
    }
}
