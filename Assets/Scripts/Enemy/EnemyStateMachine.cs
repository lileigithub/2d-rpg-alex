public class EnemyStateMachine
{
    public EnemyState currectState { get; private set; }

    public void Initialize(EnemyState enemyState)
    {
        this.currectState = enemyState;
        currectState.Enter();
    }

    public void ChangeState(EnemyState enemyState)
    {
        currectState.Exit();
        currectState = enemyState;
        currectState.Enter();
    }
}
