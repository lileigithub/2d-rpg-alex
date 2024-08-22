public class PlayerStateMachine
{
    public PlayerState currectState { get; private set; }
    public Player player { get; private set; }

    public void Initialize(PlayerState playerState)
    {
        this.currectState = playerState;
        currectState.Enter();
    }

    public void ChangeState(PlayerState playerState)
    {
        currectState.Exit();
        currectState = playerState;
        currectState.Enter();
    }


}
