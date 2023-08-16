using UnityEngine;

public class TriggerCollider : MonoBehaviour
{
    public int pointsToAdd = 10;
    public GameObject[] replacementObjects; // Add the replacement objects in the Inspector
    public GameObject[] activeObjectsAfterDestruction; // Add the active objects in the Inspector
    private GameObject tmp;

    private bool isInsideCollider = false;
    private int replacementIndex = 0;

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
                tmp.SetActive(false);
                Fishing.Intance.AddScore();

                // Activate the next object from the array
                if (replacementIndex < activeObjectsAfterDestruction.Length)
                {
                    activeObjectsAfterDestruction[replacementIndex].SetActive(true);
                    replacementIndex++;
                }
            }
        }
    }
}
