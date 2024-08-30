using UnityEngine;

/**
 * ���ܣ�
 * ->��������ʱ��⵽���棬����������ת��idle,�����������ȡ�
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

        //����ʱ��⵽���棬����������ת��idle,������������
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
