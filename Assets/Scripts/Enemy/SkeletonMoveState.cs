using UnityEngine;

public class SkeletonMoveState : SkeletonGroundState
{
    public SkeletonMoveState(EnemySkeleton enemy, EnemyStateMachine stateMachine, string animBoolName) : base(enemy, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        stateTimer = 5f;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        rb.velocity = new Vector2(enemySkeleton.moveSpeed * enemySkeleton.facingDir, rb.velocity.y);
        if (enemySkeleton.isWall || !enemySkeleton.isGrounded)
        {
            enemySkeleton.Flip();
        }
        if (stateTimer < 0)
        {
            stateMachine.ChangeState(enemySkeleton.idleState);
        }
    }
}
