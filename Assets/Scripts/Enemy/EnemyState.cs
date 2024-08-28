using UnityEngine;

public class EnemyState
{
    protected Enemy enemy;
    protected EnemyStateMachine stateMachine;
    protected Rigidbody2D rb;
    public string animBoolName { get; private set; }
    protected float stateTimer;
    //动画结束时的触发器
    protected bool triggerCalled;

    public EnemyState(Enemy enemy, EnemyStateMachine stateMachine, string animBoolName)
    {
        this.enemy = enemy;
        this.stateMachine = stateMachine;
        this.animBoolName = animBoolName;
        this.rb = enemy.rb;
    }
    public virtual void Enter()
    {
        enemy.animator.SetBool(animBoolName, true);
        triggerCalled = false;
    }

    public virtual void Exit()
    {
        enemy.animator.SetBool(animBoolName, false);
    }
    public virtual void Update()
    {
        stateTimer -= Time.deltaTime;
    }

    public void AnimationFinishTrigger()
    {
        triggerCalled = true;
    }
}
