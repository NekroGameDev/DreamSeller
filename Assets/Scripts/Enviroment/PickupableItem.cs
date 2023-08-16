using UnityEngine;

public class PickupableItem : Item
{
    public Sprite GetSprite => _renderer.sprite;

    private SpriteRenderer _renderer;

    protected override void Start()
    {
        base.Start();
        _renderer = GetComponent<SpriteRenderer>();
    }

    public override void Interact(InteractionController controller)
    {
        controller.Pickup(this);

        _rigidbody.isKinematic = true;
        _collider.enabled = false;
        _renderer.enabled = false;
    }

    public void Drop()
    {
        _rigidbody.isKinematic = false;
        _collider.enabled = true;
        _renderer.enabled = true;
    }
}
