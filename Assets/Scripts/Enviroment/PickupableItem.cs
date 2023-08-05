using UnityEngine;

public class PickupableItem : Item
{
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
