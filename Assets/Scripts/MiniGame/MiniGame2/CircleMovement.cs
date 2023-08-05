using UnityEngine;

public class CircleMovement : MonoBehaviour
{
    public Transform centerPoint;
    public float radius = 3f;
    public float rotationSpeed = 60f;

    private void Update()
    {
        // Move the UI object in a circle around the center point
        Vector3 offset = new Vector3(Mathf.Cos(Time.time * rotationSpeed) * radius, Mathf.Sin(Time.time * rotationSpeed) * radius, 0);
        transform.position = centerPoint.position + offset;
    }
}



