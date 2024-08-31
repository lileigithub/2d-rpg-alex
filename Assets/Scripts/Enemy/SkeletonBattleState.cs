using System;
using UnityEngine;

public class SkeletonBattleState : EnemyState
{
    protected EnemySkeleton enemySkeleton;

    private Transform player;
    private int moveDir;

    public SkeletonBattleState(EnemySkeleton enemy, EntityStateMachine<EnemyState> stateMachine, string animBoolName) : base(enemy, stateMachine, animBoolName)
    {
        enemySkeleton = enemy;
    }

    public override void Enter()
    {
        base.Enter();
        player = GameObject.Find("Player").transform;
    }

    public override void Exit()
    {
        base.Exit();
        enemySkeleton.animator.speed = 1;
    }

    public override void Update()
    {
        base.Update();
        float playerX = player.position.x;
        if (playerX > enemySkeleton.transform.position.x)
        {
            moveDir = 1;
        }
        else if (playerX < enemySkeleton.transform.position.x)
        {
            moveDir = -1;
        }

        enemySkeleton.setVelocityAndFacingDir(enemySkeleton.moveSpeed * 1.5f * moveDir, rb.velocity.y);
        enemySkeleton.animator.speed = 1.5f;
        //射线探测因为探测的是胶囊体，这里减的是中心距离，所以+个0.5f，保证离开范围时也检测不到了。
        if (Math.Abs(enemySkeleton.transform.position.x - playerX) > enemySkeleton.sightDistance + 0.5f)
        {
            stateMachine.ChangeState(enemySkeleton.idleState);
            return;
        }

        if (enemySkeleton.canAttack())
        {
            stateMachine.ChangeState(enemySkeleton.attackState);
            return;
        }


    }
}
