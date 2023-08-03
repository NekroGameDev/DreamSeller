using UnityEngine;

public abstract class InteractionController : MonoBehaviour
{
    [Header("Pickup")]
    [SerializeField] private Transform itemPickupPoint;

    #region [PrivateVars]

    protected PickupableItem pickupableItem;

    private Vector3 pickupPointStartPosition;

    #endregion

    protected virtual void Start()
    {
        pickupPointStartPosition = itemPickupPoint.localPosition;
    }

    protected abstract void Interact();

    public virtual void Pickup(PickupableItem item)
    {
        pickupableItem = item;
        pickupableItem.transform.position = itemPickupPoint.position;
        pickupableItem.transform.parent = itemPickupPoint.transform;
    }

    protected virtual void DropItem()
    {
        if (pickupableItem == null)
        {
            return;
        }

        pickupableItem.Drop();
        pickupableItem.transform.parent = null;
        pickupableItem = null;
    }

    protected void SetPickupPoint(bool isRight)
    {
        itemPickupPoint.transform.localPosition = isRight ? pickupPointStartPosition : pickupPointStartPosition * -1f;
    }
}
