using UnityEngine;

public abstract class InteractionController : MonoBehaviour
{
    [Header("Pickup")]
    [SerializeField] private SpriteRenderer itemPickupPoint;
    [SerializeField] private Transform itemDropPoint;

    #region [PrivateVars]

    protected PickupableItem pickupableItem;

    private Vector3 pickupPointStartPosition;

    #endregion

    protected virtual void Start()
    {
        //pickupPointStartPosition = itemPickupPoint.localPosition;
    }

    protected abstract void Interact();

    public virtual void Pickup(PickupableItem item)
    {
        pickupableItem = item;
        itemPickupPoint.sprite = pickupableItem.GetSprite;
    }

    protected virtual void DropItem()
    {
        if (pickupableItem == null)
        {
            return;
        }

        pickupableItem.Drop();
        pickupableItem.transform.position = itemDropPoint.position;
        pickupableItem = null;
        itemPickupPoint.sprite = null;
    }
}
