using UnityEngine;
using UnityEngine.Events;

public class Events : MonoBehaviour
{
    [SerializeField] private UnityEvent onActivateEvent;

    public void ActivateEvents()
    {
        onActivateEvent?.Invoke();
    }
}
