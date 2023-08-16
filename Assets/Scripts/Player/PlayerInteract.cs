using System.Collections;
using TMPro;
using UnityEngine;

public class PlayerInteract : InteractionController
{
    [Header("ItemInfo")]
    [SerializeField] private GameObject itemInfoPanel;
    [SerializeField] private TextMeshProUGUI textItemInfo;
    [SerializeField] private LayerMask itemLayer;

    [Header("Interact")]
    [SerializeField] private LayerMask interactLayer;
    [SerializeField] private float interactRange = 1;

    #region [PrivateVars]

    private Coroutine infoCoroutine;

    private PlayerController playerController;
    private CameraController cameraController;

    #endregion

    protected override void Start()
    {
        base.Start();

        playerController = GetComponent<PlayerController>();
        cameraController = GetComponent<CameraController>();
    }

    private void Update()
    {
        GetItemInfo();
        Interact();
    }

    #region [Interact]

    protected override void Interact()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (pickupableItem == null)
            {
                Try2Interact();
            }
            else
            {
                DropItem();
            }
        }
    }

    private void Try2Interact()
    {
        Ray ray = new Ray(transform.position, transform.right * playerController.GetCurrentDirection);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, 1, interactLayer);

        if (hit)
        {
            if (hit.transform.TryGetComponent(out Interactable interactable))
            {
                interactable.Interact(this);
            }
        }
    }

    #endregion

    #region [ItemInfo]

    private void GetItemInfo()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cameraController.GetCurrentCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity, itemLayer);

            if (hit)
            {
                if (hit.transform.TryGetComponent(out ItemInfo item))
                {
                    if (infoCoroutine != null)
                    {
                        StopCoroutine(infoCoroutine);
                    }

                    infoCoroutine = StartCoroutine(ShowInfoCoroutine(item));
                }
            }
        }
    }

    private IEnumerator ShowInfoCoroutine(ItemInfo item)
    {
        if (itemInfoPanel == null)
        {
            Debug.LogWarning($"Set text item info; Item info: {item.GetItemInfo}");
            yield break;
        }

        itemInfoPanel.SetActive(true);
        textItemInfo.text = item.GetItemInfo;

        yield return new WaitForSeconds(item.GetTime2Show);

        itemInfoPanel.SetActive(false);
        textItemInfo.text = string.Empty;
    }

    #endregion
}
