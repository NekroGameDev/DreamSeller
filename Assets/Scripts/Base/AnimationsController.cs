using UnityEngine;

public class AnimationsController : MonoBehaviour
{
    [SerializeField] protected Animator animator;
    [SerializeField] protected SpriteRenderer spriteRenderer;

    public void FlipSprite(bool isFlip)
    {
        spriteRenderer.flipX = isFlip;
    }
}
