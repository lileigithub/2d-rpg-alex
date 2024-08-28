using UnityEngine;

/**
 * combo����
 * ���ܣ�1.�д�������ι��� 2.�����ڼ��׷��һ�ι��� 3.����ʱ��Сλ�ƣ����ӱ�����
 */
public class PlayerPrimaryAttack : PlayerState
{
    //������combo����
    private int comboCounter;
    private float lastTimeAttacked;
    //combo���ʱ��
    private float comboWindowtime = .5f;

    //׷�ӹ����Ĵ���
    protected int appendAttackCount;
    public PlayerPrimaryAttack(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        if (comboCounter > 2 || Time.time > lastTimeAttacked + comboWindowtime)
        {
            comboCounter = 0;
        }
        player.animator.SetInteger("ComboCounter", comboCounter);
        float attackDir = player.facingDir;
        //��⹥��ʱ=ǰ�����뷽���Ծ���������
        if (xInput != 0)
        {
            attackDir = xInput;
        }
        //����ʱ��Сλ�ƣ����ӱ�����
        player.setVelocity(player.attackMovements[comboCounter].x * attackDir, player.attackMovements[comboCounter].y);
        //enemy.animator.speed = 3;
    }

    public override void Exit()
    {
        base.Exit();
        comboCounter++;
        lastTimeAttacked = Time.time;
        //enemy.animator.speed = 1;
    }

    public override void Update()
    {
        base.Update();

        //���ڹ�����������׷��һ�ι�����������
        if (Input.GetKeyDown(KeyCode.K))
        {
            if (appendAttackCount < 1)
            {
                appendAttackCount++;
            }
        }
        if (triggerCalled)
        {
            if (appendAttackCount > 0)
            {
                appendAttackCount--;
                stateMachine.ChangeState(player.primaryAttack);
                return;
            }
            else
            {
                stateMachine.ChangeState(player.idleState);
                return;
            }
        }
    }
}
