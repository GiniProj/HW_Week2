using UnityEngine;
using UnityEngine.InputSystem;

public class ObjectHider : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [Header("Input Settings")]
    [Tooltip("Input Action that will trigger the visibility toggle. Set this in the Inspector after creating an Input Action")]
    [SerializeField] private InputAction toggleVisibility;

    private SpriteRenderer spriteRenderer;

    void OnEnable()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            Debug.LogWarning("No SpriteRenderer found on " + gameObject.name + ". ObjectHider requires a SpriteRenderer component.");
            return;
        }

        if (toggleVisibility == null)
        {
            Debug.LogError("Toggle Visibility Input Action not set on " + gameObject.name);
            return;
        }

        toggleVisibility.Enable();
        toggleVisibility.performed += OnToggleVisibility;
    }

    void OnDisable()
    {
        if (toggleVisibility != null)
        {
            toggleVisibility.Disable();
            toggleVisibility.performed -= OnToggleVisibility;
        }
    }

    private void OnToggleVisibility(InputAction.CallbackContext context)
    {
        if (spriteRenderer != null)
            spriteRenderer.enabled = !spriteRenderer.enabled;
    }
}
