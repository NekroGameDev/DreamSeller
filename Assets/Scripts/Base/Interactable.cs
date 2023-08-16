using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public virtual void Interact(InteractionController controller)
    {
        Debug.Log($"Interact with {transform.name}");
    }
}
