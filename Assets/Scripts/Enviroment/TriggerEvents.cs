using UnityEngine;
using UnityEngine.Events;

public class TriggerEvents : MonoBehaviour
{
    [SerializeField] private UnityEvent onTriggerEnter;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerController player))
        {
            onTriggerEnter?.Invoke();

            player.StopMove();
            player.transform.position = transform.position;
            player.transform.parent = transform;
            player.enabled = false;
        }
    }
}
