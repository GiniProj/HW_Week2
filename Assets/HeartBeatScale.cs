using UnityEngine;

public class HeartBeatScale : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [Header("Heartbeat Settings")]
    [Tooltip("Minimum scale factor the object will shrink to")]
    [Range(0.1f, 1f)] // Prevent negative or zero scale, max at normal size
    [SerializeField] private float minScale = 0.8f;

    [Tooltip("Maximum scale factor the object will grow to")]
    [Range(1f, 3f)] // Start from normal size, prevent excessive growth
    [SerializeField] private float maxScale = 1.2f;

    [Tooltip("Speed of the pulsing effect (higher values = faster pulses)")]
    [Range(0.1f, 5f)] // Prevent too slow or too fast pulsing
    [SerializeField] private float pulseSpeed = 1f;
    
    private Vector2 originalScale;
    void Start()
    {
        originalScale = transform.localScale;

        // Validate that maxScale is greater than minScale
        if (maxScale <= minScale)
        {
            Debug.LogWarning("HeartbeatScale: maxScale must be greater than minScale. Adjusting maxScale.");
            maxScale = minScale + 0.1f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float scaleFactor = Mathf.Lerp(minScale, maxScale, 
            (Mathf.Sin(Time.time * pulseSpeed * Mathf.PI) + 1f) / 2f);
        transform.localScale = originalScale * scaleFactor;
    }
}
