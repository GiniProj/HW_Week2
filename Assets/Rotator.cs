using UnityEngine;

public class Rotator : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // 2D Rotation Settings - Rotation on the Z axis
    [Header("2D Rotation Settings")]
    [Tooltip("Speed of rotation in degrees per second")]
    [Range(-360f, 360f)]  // Full Range is -360 to 360 degrees per second
    [SerializeField] private float rotationSpeed = 90f;  // default rotation speed in degrees per second

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
}
