using UnityEngine;

public class PlayerInteract : InteractionController
{
    [Header("Interact")]
    [SerializeField] private LayerMask interactLayer;
    [SerializeField] private float interactRange = 1;

    #region [PrivateVars]

    private PlayerController playerController;

    #endregion

    protected override void Start()
    {
        base.Start();

        playerController = GetComponent<PlayerController>();
    }

    private void Update()
    {
        Interact();
        SetPickupPoint(playerController.GetCurrentDirection == 1 ? true : false);
    }

    protected override void Interact()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (pickupableItem == null)
            {
                CastRay();
            }
            else
            {
                DropItem();
            }
        }
    }

    private void CastRay()
    {
        Ray ray = new Ray(transform.position, transform.right * playerController.GetCurrentDirection);
        RaycastHit hit;    

        if (Physics.Raycast(ray, out hit, interactRange, interactLayer))
        {
            if (hit.transform.TryGetComponent(out Interactable interactable))
            {
                interactable.Interact(this);
            }
        }
    }
}
