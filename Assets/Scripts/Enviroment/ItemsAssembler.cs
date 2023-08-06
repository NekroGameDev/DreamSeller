using UnityEngine;
using UnityEngine.Events;

public class ItemsAssembler : MonoBehaviour
{
    [SerializeField] private Item assemblerableItem;

    [Header("Events")]
    [SerializeField] private UnityEvent onSuccess;
    [SerializeField] private UnityEvent onFailure;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Item item))
        {
            if (item == assemblerableItem)
            {
                onSuccess?.Invoke();
                Destroy(item.gameObject);
            }
            else
            {
                onFailure?.Invoke();
            }
        }
    }
}
