using UnityEngine;

/**
 * combo攻击
 * 功能：1.有次序地三次攻击 2.攻击期间可追加一次攻击 3.攻击时有小位移，增加表现力
 */
public class PlayerPrimaryAttack : PlayerState
{
    public static readonly string ComboCounterName = "ComboCounter";

    //攻击的combo次序
    private int comboCounter;
    private float lastTimeAttacked;
    //combo间隔时间
    private float comboWindowtime = .5f;

    //追加攻击的次数
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
        //这里不用update()里的xInput而是重新获取，因为上一次update()可能不是最新的，Enter()时输入改变了。
        float nowXInput = Input.GetAxisRaw("Horizontal");
        //检测攻击时=前的输入方向，以决定面向方向
        if (nowXInput != 0)
        {
            attackDir = nowXInput;
        }
        //攻击时有小位移，增加表现力
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

        //可在攻击进行中再追加一次攻击，更流畅
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
