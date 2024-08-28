public class SkeletonGroundState : EnemyState
{
    protected EnemySkeleton enemySkeleton;
    public SkeletonGroundState(EnemySkeleton enemy, EnemyStateMachine stateMachine, string animBoolName) : base(enemy, stateMachine, animBoolName)
    {
        enemySkeleton = enemy;
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
        if (enemySkeleton.isPlayerDetected())
        {
            stateMachine.ChangeState(enemySkeleton.battleState);
        }
    }
}