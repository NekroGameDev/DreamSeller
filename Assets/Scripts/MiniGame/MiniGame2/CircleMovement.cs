using UnityEngine;

public class CircleMovement : MonoBehaviour
{
    public Transform centerPoint;
    public float radius = 350f;
    public float initialRotationSpeed = 3f;
    public float rotationSpeedIncreaseRate = 0.05f; // Rate of speed increase per second
    public float maxRotationSpeed = 6f; // Maximum allowed rotation speed

    private float currentRotationSpeed;

    private void Start()
    {
        currentRotationSpeed = initialRotationSpeed;
    }

    private void Update()
    {
        // Increase rotation speed over time
        currentRotationSpeed += rotationSpeedIncreaseRate * Time.deltaTime;

        // Clamp the rotation speed to the maximum allowed speed
        currentRotationSpeed = Mathf.Clamp(currentRotationSpeed, initialRotationSpeed, maxRotationSpeed);

        // Move the UI object in a circle around the center point
        Vector3 offset = new Vector3(Mathf.Cos(Time.time * currentRotationSpeed) * radius, Mathf.Sin(Time.time * currentRotationSpeed) * radius, 0);
        transform.position = centerPoint.position + offset;
    }
}
