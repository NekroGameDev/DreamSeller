using UnityEngine;

public class PickupableItem : Interactable
{
    private Rigidbody _rigidbody;
    private Collider _collider;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _collider = GetComponent<Collider>();
    }

    public override void Interact(InteractionController controller)
    {
        controller.Pickup(this);

        _rigidbody.isKinematic = true;
        _collider.enabled = false;
    }

    public void Drop()
    {
        _rigidbody.isKinematic = false;
        _collider.enabled = true;
    }
}
