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
                Debug.Log("attacker.stats:" + (attacker.stats != null));
                Debug.Log("victim.stats:" + (victim.stats != null));
                attacker.stats.DoDamage(victim.stats);
                victim.ChangeToBattle();
            }
        }
    }
}
