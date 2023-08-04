using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickToMove : MonoBehaviour, IPointerClickHandler
{
    public float moveDistance = 100.0f; 
    public LayerMask obstacleLayer; 
    private Vector3 originalPosition;
    private bool isMoving = false;
    private static bool canClick = true;

    private void Start()
    {
        originalPosition = transform.position;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (canClick && !isMoving)
        {
            StartCoroutine(MoveObject());
        }
    }

    private bool CheckObstacle(Vector3 targetPosition)
    {
        Collider2D hitCollider = Physics2D.OverlapCircle(targetPosition, 0.1f, obstacleLayer);
        return hitCollider == null;
    }

    private IEnumerator MoveObject()
    {
        isMoving = true;
        canClick = false;

        Vector3 targetPosition = transform.position + Vector3.up * moveDistance; 

        if (!CheckObstacle(targetPosition))
        {
            targetPosition = transform.position + Vector3.right * moveDistance;
            if (!CheckObstacle(targetPosition))
            {
                targetPosition = transform.position + Vector3.left * moveDistance;
                if (!CheckObstacle(targetPosition))
                {
                    targetPosition = transform.position + Vector3.down * moveDistance;
                    if (!CheckObstacle(targetPosition))
                    {
                        Debug.Log("No available direction to move.");
                        isMoving = false;
                        canClick = true;
                        yield break;
                    }
                }
            }
        }

        float elapsedTime = 0f;
        float moveTime = 1.0f; 

        Vector3 startingPosition = transform.position;

        while (elapsedTime < moveTime)
        {
            transform.position = Vector3.Lerp(startingPosition, targetPosition, elapsedTime / moveTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition;
        isMoving = false;

        canClick = true;
    }
}
