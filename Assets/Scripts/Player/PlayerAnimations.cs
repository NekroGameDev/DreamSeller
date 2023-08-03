using UnityEngine;

public class PlayerAnimations : AnimationsController
{
    #region [PrivateVars]

    private readonly string STATE = "State";
    private readonly string MOVE_HORIZONTAL = "MoveX";
    private readonly string MOVE_VERTICAL = "MoveZ";

    #endregion

    public void SetMove(int state, int moveX, int moveZ)
    {
        if (animator == null)
        {
            Debug.LogWarning("Set animator");
            return;
        }

        if (Mathf.Abs(moveX) + Mathf.Abs(moveZ) > 0)
        { 
            animator.SetFloat(MOVE_HORIZONTAL, Mathf.Abs(moveX));
            animator.SetFloat(MOVE_VERTICAL, moveZ);
        }

        animator.SetFloat(STATE, state);

        if (moveX != 0)
        {
            FlipSprite(moveX > 0 ? true : false);
        }
    }
}
