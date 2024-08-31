using UnityEngine;

public class PlayerAnimationTriggers : MonoBehaviour
{
    private Player attacker => GetComponentInParent<Player>();

    private void Animationtrigger()
    {
        attacker.AnimationTrigger();
    }

    private void AttackTrigger()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(attacker.attackCheck.position, attacker.attackRadius);
        foreach (var collider in colliders)
        {
            Enemy victim = collider.GetComponent<Enemy>();
            if (victim != null)
            {
                victim.DamageBy(attacker);
                victim.ChangeToBattle();
            }
        }
    }
}
