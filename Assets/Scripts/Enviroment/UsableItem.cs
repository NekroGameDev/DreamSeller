using UnityEngine;
using UnityEngine.Events;

public class UsableItem : Item
{
    [Header("Settings")]
    [SerializeField] private bool isSelfDestroy = true;
    [SerializeField] private bool isInteractable = true;

    [Header("Timer")]
    [SerializeField] private bool isActivateTimer = false;
    [SerializeField] private float timerDuration;

    [Header("Events")]
    [SerializeField] private UnityEvent onUseItem;
    [SerializeField] private UnityEvent onTimerEnd;
    
    public bool IsInteractable 
    {
        get => isInteractable;
        set => isInteractable = value;
    }

    public override void Interact(InteractionController controller)
    {
        if (!IsInteractable)
        {
            return;
        }

        onUseItem?.Invoke();
    
        if (isSelfDestroy)
        {
            Destroy(gameObject);
        }

        if ((isActivateTimer) && (!isSelfDestroy))
        {
            Invoke(nameof(ActivateTimer), timerDuration);
        }
    }

    private void ActivateTimer()
    {
        onTimerEnd?.Invoke();
    }
}
