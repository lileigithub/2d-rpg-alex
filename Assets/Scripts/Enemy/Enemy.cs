using UnityEngine;

public class Enemy : Entity
{

    protected EntityStateMachine<EnemyState> stateMachine { get; set; }

    #region Collision info
    [Header("Collision info")]
    [SerializeField] protected Transform playerCheck;
    [SerializeField] protected LayerMask playerLayerMask;
    #endregion

    public float sightDistance = 10;
    public float attackDistance = 1;

    public float stunnedDuraction = 1f;
    public Vector2 stunnedDirection;

    [SerializeField] private GameObject counterImage;
    private bool canBeStunned;

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
        stateMachine.currectState.Update();

    }

    public virtual RaycastHit2D isPlayerDetected() => Physics2D.Raycast(playerCheck.position, Vector2.right * facingDir, sightDistance, playerLayerMask);
    public virtual RaycastHit2D canAttack() => Physics2D.Raycast(playerCheck.position, Vector2.right * facingDir, attackDistance, playerLayerMask);

    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(playerCheck.position, new Vector2(playerCheck.position.x + sightDistance * facingDir, playerCheck.position.y));
        Gizmos.color = Color.red;
        Gizmos.DrawLine(playerCheck.position, new Vector2(playerCheck.position.x + attackDistance * facingDir, playerCheck.position.y));
    }

    public void AnimationTrigger()
    {
        if (stateMachine.currectState != null)
            stateMachine.currectState.AnimationFinishTrigger();
    }

    public void CanAttack()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(attackCheck.position, attackRadius);
        foreach (var collider in colliders)
        {
            Player victim = collider.GetComponent<Player>();
            if (victim != null)
                victim.DamageBy(this);
        }
    }

    public void OpenCountWindow()
    {
        canBeStunned = true;
        counterImage.SetActive(true);
    }

    public void CloseCountWindow()
    {
        canBeStunned = false;
        counterImage.SetActive(false);
    }

    public virtual bool CanBeAndStunned()
    {
        if (canBeStunned)
        {
            CloseCountWindow();
            return true;
        }
        return false;
    }

    public virtual void ChangeToBattle()
    {

    }
}