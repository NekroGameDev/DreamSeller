using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class TagsCell : MonoBehaviour
{
    [SerializeField] private LayerMask cellsLayer;
    [SerializeField] private float distance;
    [SerializeField] private float offsetX;
    [SerializeField] private float offsetY;

    private Collider2D _collider;
    private bool isMoving = false;
    protected UnityAction onStartMove;
    protected UnityAction<Vector3> onStopMove;

    protected virtual void Start()
    {
        _collider = GetComponent<Collider2D>();
    }

    private void OnMouseDown()
    {
        CheckCells();
    }

    private void CheckCells()
    {
        _collider.enabled = false;

        if (!Physics2D.Raycast(transform.position, transform.up, distance, cellsLayer))
        {
            Vector2 newPosition = new Vector2(transform.position.x, transform.position.y + 1 * offsetY);
            StartMoving(newPosition);
        }
        else if (!Physics2D.Raycast(transform.position, transform.up * -1, distance, cellsLayer))
        {
            Vector2 newPosition = new Vector2(transform.position.x, transform.position.y - 1 * offsetY);
            StartMoving(newPosition);
        }
        else if (!Physics2D.Raycast(transform.position, transform.right, distance, cellsLayer))
        {
            Vector2 newPosition = new Vector2(transform.position.x + 1 * offsetX, transform.position.y);
            StartMoving(newPosition);
        }
        else if (!Physics2D.Raycast(transform.position, transform.right * -1, distance, cellsLayer))
        {
            Vector2 newPosition = new Vector2(transform.position.x - 1 * offsetX, transform.position.y);
            StartMoving(newPosition);
        }

        _collider.enabled = true;
    }

    private void StartMoving(Vector2 newPosition)
    {
        if (isMoving)
        {
            return;
        }

        StartCoroutine(Moving(newPosition));
    }

    private IEnumerator Moving(Vector2 newPosition)
    {
        _collider.enabled = false;
        onStartMove?.Invoke();
        isMoving = true;

        float elapsedTime = 0f;
        float moveTime = 0.5f;

        Vector3 startingPosition = transform.position;

        while (elapsedTime < moveTime)
        {
            transform.position = Vector3.LerpUnclamped(startingPosition, newPosition, elapsedTime / moveTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = newPosition;
        isMoving = false;
        onStopMove?.Invoke(startingPosition);
        _collider.enabled = true;
    }
}
