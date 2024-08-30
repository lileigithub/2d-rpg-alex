using UnityEngine;

public class PlayerAnimationTriggers : MonoBehaviour
{
    private Player player => GetComponentInParent<Player>();

    private void Animationtrigger()
    {
        player.AnimationTrigger();
    }
}
