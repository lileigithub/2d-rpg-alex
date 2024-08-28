using UnityEngine;

public class Enemy : Entity
{
    #region State
    public EnemyStateMachine stateMachine { get; private set; }
    #endregion

    #region Collision info
    [Header("Collision info")]
    [SerializeField] protected Transform playerCheck;
    [SerializeField] protected LayerMask playerLayerMask;
    #endregion

    protected override void Awake()
    {
        base.Awake();
        stateMachine = new EnemyStateMachine();
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

    public virtual RaycastHit2D isPlayerDetected() => Physics2D.Raycast(playerCheck.position, Vector2.right * facingDir, 5, playerLayerMask);

    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(playerCheck.position, new Vector2(playerCheck.position.x + 5 * facingDir, playerCheck.position.y));
    }
}