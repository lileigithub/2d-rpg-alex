public class SkeletonMoveState : SkeletonGroundState
{
    public SkeletonMoveState(EnemySkeleton enemy, EntityStateMachine<EnemyState> stateMachine, string animBoolName) : base(enemy, stateMachine, animBoolName)
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
        enemy.setVelocityAndFacingDir(enemySkeleton.moveSpeed * enemySkeleton.facingDir, rb.velocity.y);
        if (enemySkeleton.isWall || !enemySkeleton.isGrounded)
        {
            enemySkeleton.Flip();
        }

        if (stateTimer < 0)
        {
            stateMachine.ChangeState(enemySkeleton.idleState);
            return;
        }
    }
}
