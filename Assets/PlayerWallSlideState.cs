using UnityEngine;

public class PlayerWallSlideState : PlayerState
{
    private float stopSlideTimer;
    private float stopSlideCoolDownTime = 0.19f;
    private float keepY;
    public PlayerWallSlideState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
        stopSlideTimer = 0;

    }

    public override void Update()
    {
        base.Update();
        if (stopSlideTimer == 0) keepY = player.transform.position.y;
        if (xInput == -player.facingDir)
        {
            //输入与面向相反时，计时，这段时间停止下滑，并可以jump
            stopSlideTimer += Time.deltaTime;
        }
        if (Input.GetButtonDown("Jump"))
        {
            stopSlideTimer = 0;
            stateMachine.ChangeState(player.wallJumpState);
            return;
        }
        //到地面 或超过停止下滑时间，进入idle
        if (player.isGroundDetected() || stopSlideTimer > stopSlideCoolDownTime)
        {
            stopSlideTimer = 0;
            stateMachine.ChangeState(player.idleState);
            return;
        }

        if (yInput < 0)
            player.setVelocity(rb.velocity.x, rb.velocity.y);
        else if (stopSlideTimer > 0 && stopSlideTimer <= stopSlideCoolDownTime)
        {
            //在停止期间，固定住y
            player.transform.position = new Vector2(player.transform.position.x, keepY);
            player.setVelocity(rb.velocity.x, 0);
        }
        else
            player.setVelocity(rb.velocity.x, rb.velocity.y * 0.5f);
    }
}
