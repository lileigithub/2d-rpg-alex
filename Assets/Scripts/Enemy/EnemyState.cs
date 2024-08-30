public class EnemyState : EntityState
{
    protected Enemy enemy;
    protected EntityStateMachine<EnemyState> stateMachine;
    public EnemyState(Enemy entity, EntityStateMachine<EnemyState> stateMachine, string animBoolName) : base(entity, animBoolName)
    {
        enemy = entity;
        this.stateMachine = stateMachine;
    }
}
