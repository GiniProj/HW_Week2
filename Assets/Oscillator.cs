using System;
using UnityEngine;


public class Oscillator : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [Header("Oscillator Settings")]
    [Tooltip("Horizontal Movements (Positive values move right, Negative values move left)")]
    [SerializeField] private Vector2 directionMovement = Vector2.right;  // Right Movement by default

    [Tooltip("Limit of the object's movement from its center position")]
    [Range(0.1f, 2f)]  // Min and Max range
    [SerializeField] private float limitObjectMovement = 2f;  // Default amplitude of 2 units

    [Tooltip("Speed of the object's movement (Higher values = faster movement)")]
    [Range(0.1f, 2f)]  // Min and Max range - Prevent too slow or too fast oscillations
    [SerializeField] private float speedObjectMovement = 1f;  // Default frequency of 1 unit

    [Tooltip("The starting position of the object")]
    [SerializeField] private Vector2 startPosition;  // Default start position

    void Start()
    {
        startPosition = transform.position;  // Set the starting position of the object
    }

    // Update is called once per frame
    void Update()
    {
        float factor = Mathf.Sin(Time.time * Mathf.PI*speedObjectMovement);  // Calculate the factor of the object's movement (Repeated wave Movement value -1 to 1)

        // Move the object to the new position based on the factor, direction, and limit of movement
        transform.position = startPosition + factor * limitObjectMovement * directionMovement.normalized;
    }
}
