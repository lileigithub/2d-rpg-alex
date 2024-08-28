using System;
using UnityEngine;

public class SkeletonBattleState : SkeletonGroundState
{
    private Transform player;
    private int moveDir;
    public SkeletonBattleState(EnemySkeleton enemy, EnemyStateMachine stateMachine, string animBoolName) : base(enemy, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player = GameObject.Find("Player").transform;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        float playerX = player.position.x;
        Debug.Log("playerX:" + playerX);
        if (playerX > enemySkeleton.transform.position.x)
        {
            moveDir = 1;
        }
        else if (playerX < enemySkeleton.transform.position.x)
        {
            moveDir = -1;
        }

        enemySkeleton.setVelocity(enemySkeleton.moveSpeed * 1.5f * moveDir, rb.velocity.y);
        if (Math.Abs(enemySkeleton.transform.position.x - playerX) > 10)
        {
            stateMachine.ChangeState(enemySkeleton.idleState);
        }


    }
}
