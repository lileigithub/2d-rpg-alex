using UnityEngine;

public class PlayerAirState : PlayerState
{
    public PlayerAirState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
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
        player.setVelocity(xInput * player.moveSpeed * 0.8f, rb.velocity.y, xInput);
        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("air" + "State, key true, isGround " + player.isGroundDetected());
        }
        if (player.isGroundDetected() && Input.GetButtonDown("Jump"))
        {
            stateMachine.ChangeState(player.jumpState);
            return;
        }

        if (player.isGroundDetected() || (rb.velocity.x == 0 && rb.velocity.y == 0))
        {
            stateMachine.ChangeState(player.idleState);
            return;
        }
        if (player.isWallDetected() && !player.isGroundDetected())
        {
            stateMachine.ChangeState(player.wallSlideStatte);
            return;
        }

    }
}
