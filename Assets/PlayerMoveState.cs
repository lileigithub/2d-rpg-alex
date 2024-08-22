using UnityEngine;

public class PlayerMoveState : PlayerGroundedState
{
    public PlayerMoveState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
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
        if (Input.GetButtonDown("Jump"))
        {
            //Debug.Log(animBoolName + "State, key true, isGround " + player.isGroundDetected());
            return;
        }
        player.setVelocity(xInput * player.moveSpeed, rb.velocity.y);
        if (xInput == 0 && player.isGroundDetected())
        {
            stateMachine.ChangeState(player.idleState);
        }
    }


}
