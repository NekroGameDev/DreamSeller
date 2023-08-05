using UnityEngine;

public class TriggerCollider : MonoBehaviour
{
    public int pointsToAdd = 10;
    private GameObject tmp;

    private bool isInsideCollider = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Other"))
        {
            isInsideCollider = true;
            tmp = other.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Other"))
        {
            isInsideCollider = false;
            tmp = null;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isInsideCollider && tmp != null)
            {
                Debug.Log("Points earned: " + pointsToAdd);
                Destroy(tmp);
            }
        }
    }
}
