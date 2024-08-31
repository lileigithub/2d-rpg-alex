using UnityEngine;

/**
 * 沿墙下滑
 * 功能：1.下滑 2.要离开墙时，可短暂停止下滑 3.利用静止可向外跳 4.下滑状态可反墙跳
 * 可转移到：Jump、idle
 */
public class PlayerWallSlideState : PlayerState
{
    //停止下滑计时器
    private float stopSlideTimer;
    //停止下滑时间
    private float stopSlideCoolDownTime = 0.19f;
    //停止下滑的位置
    private float keepY;
    public PlayerWallSlideState(Player player, EntityStateMachine<PlayerState> stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
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
        //不在墙上 或到地面 或超过停止下滑时间，进入idle
        if (!player.isWall || player.isGrounded || stopSlideTimer > stopSlideCoolDownTime)
        {
            stopSlideTimer = 0;
            stateMachine.ChangeState(player.idleState);
            return;
        }

        if (yInput < 0)
            player.setVelocityAndFacingDir(0, rb.velocity.y);
        else if (stopSlideTimer > 0 && stopSlideTimer <= stopSlideCoolDownTime)
        {
            //在停止时间内，位置y保持不变
            player.transform.position = new Vector2(player.transform.position.x, keepY);
            player.setVelocityAndFacingDir(rb.velocity.x, 0);
        }
        else
            //减速下滑 这里要写0，不能写rb.velocity.x，因为和tile map墙体碰撞时会有一个反作用力使x为负数,而x又决定面朝方向。
            //我已经把tile map 的composite collider 2D 的 offset distance 设为0了，这样就没有反作用力了，或者说反向的速度。
            player.setVelocityAndFacingDir(0, rb.velocity.y * 0.3f);
    }
}
