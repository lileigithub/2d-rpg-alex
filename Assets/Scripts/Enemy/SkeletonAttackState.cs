public class SkeletonAttackState : EnemyState
{
    protected EnemySkeleton enemySkeleton;

    public SkeletonAttackState(EnemySkeleton enemy, EntityStateMachine<EnemyState> stateMachine, string animBoolName) : base(enemy, stateMachine, animBoolName)
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
        //triggerCalledÊ¹¹¥»÷Íê³É
        if (!enemySkeleton.canAttack() && triggerCalled)
        {
            stateMachine.ChangeState(enemySkeleton.battleState);
            return;
        }
    }
}
