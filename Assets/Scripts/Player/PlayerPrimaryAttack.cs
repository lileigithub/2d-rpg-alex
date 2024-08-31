using UnityEngine;

/**
 * combo����
 * ���ܣ�1.�д�������ι��� 2.�����ڼ��׷��һ�ι��� 3.����ʱ��Сλ�ƣ����ӱ�����
 */
public class PlayerPrimaryAttack : PlayerState
{
    public static readonly string ComboCounterName = "ComboCounter";

    //������combo����
    private int comboCounter;
    private float lastTimeAttacked;
    //combo���ʱ��
    private float comboWindowtime = .5f;

    //׷�ӹ����Ĵ���
    protected int appendAttackCount;
    public PlayerPrimaryAttack(Player player, EntityStateMachine<PlayerState> stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        if (comboCounter > 2 || Time.time > lastTimeAttacked + comboWindowtime)
        {
            comboCounter = 0;
        }
        player.animator.SetInteger(ComboCounterName, comboCounter);
        float attackDir = player.facingDir;
        //���ﲻ��update()���xInput�������»�ȡ����Ϊ��һ��update()���ܲ������µģ�Enter()ʱ����ı��ˡ�
        float nowXInput = Input.GetAxisRaw("Horizontal");
        //��⹥��ʱ=ǰ�����뷽���Ծ���������
        if (nowXInput != 0)
        {
            attackDir = nowXInput;
        }
        //����ʱ��Сλ�ƣ����ӱ�����
        player.setVelocityAndFacingDir(player.attackMovements[comboCounter].x * attackDir, player.attackMovements[comboCounter].y);
        //attacker.animator.speed = 3;
    }

    public override void Exit()
    {
        base.Exit();
        comboCounter++;
        lastTimeAttacked = Time.time;
        //attacker.animator.speed = 1;
    }

    public override void Update()
    {
        base.Update();

        if (Input.GetButtonDown("Jump"))
        {
            stateMachine.ChangeState(player.jumpState);
            return;
        }

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
