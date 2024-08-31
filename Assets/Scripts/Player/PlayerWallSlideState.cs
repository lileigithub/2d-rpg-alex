using UnityEngine;

/**
 * ��ǽ�»�
 * ���ܣ�1.�»� 2.Ҫ�뿪ǽʱ���ɶ���ֹͣ�»� 3.���þ�ֹ�������� 4.�»�״̬�ɷ�ǽ��
 * ��ת�Ƶ���Jump��idle
 */
public class PlayerWallSlideState : PlayerState
{
    //ֹͣ�»���ʱ��
    private float stopSlideTimer;
    //ֹͣ�»�ʱ��
    private float stopSlideCoolDownTime = 0.19f;
    //ֹͣ�»���λ��
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
            //�����������෴ʱ����ʱ�����ʱ��ֹͣ�»���������jump
            stopSlideTimer += Time.deltaTime;
        }

        if (Input.GetButtonDown("Jump"))
        {
            stopSlideTimer = 0;
            stateMachine.ChangeState(player.wallJumpState);
            return;
        }
        //����ǽ�� �򵽵��� �򳬹�ֹͣ�»�ʱ�䣬����idle
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
            //��ֹͣʱ���ڣ�λ��y���ֲ���
            player.transform.position = new Vector2(player.transform.position.x, keepY);
            player.setVelocityAndFacingDir(rb.velocity.x, 0);
        }
        else
            //�����»� ����Ҫд0������дrb.velocity.x����Ϊ��tile mapǽ����ײʱ����һ����������ʹxΪ����,��x�־����泯����
            //���Ѿ���tile map ��composite collider 2D �� offset distance ��Ϊ0�ˣ�������û�з��������ˣ�����˵������ٶȡ�
            player.setVelocityAndFacingDir(0, rb.velocity.y * 0.3f);
    }
}
