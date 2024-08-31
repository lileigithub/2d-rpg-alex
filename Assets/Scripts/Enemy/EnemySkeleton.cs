public class EnemySkeleton : Enemy
{
    public SkeletonIdleState idleState { get; private set; }
    public SkeletonMoveState moveState { get; private set; }
    public SkeletonBattleState battleState { get; private set; }
    public SkeletonAttackState attackState { get; private set; }
    public SkeletonStunnedState stunnedState { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        stateMachine = new EntityStateMachine<EnemyState>();
        idleState = new SkeletonIdleState(this, stateMachine, "Idle");
        moveState = new SkeletonMoveState(this, stateMachine, "Move");
        battleState = new SkeletonBattleState(this, stateMachine, "Move");
        attackState = new SkeletonAttackState(this, stateMachine, "Attack");
        stunnedState = new SkeletonStunnedState(this, stateMachine, "Stunned");
    }
    protected override void Start()
    {
        base.Start();
        stateMachine.Initialize(idleState);
    }

    protected override void Update()
    {
        base.Update();
    }

    public override bool CanBeAndStunned()
    {
        if (base.CanBeAndStunned())
        {
            stateMachine.ChangeState(stunnedState);
            return true;
        }
        return false;
    }

    public override void ChangeToBattle()
    {
        base.ChangeToBattle();
        stateMachine.ChangeState(battleState);
    }

}
