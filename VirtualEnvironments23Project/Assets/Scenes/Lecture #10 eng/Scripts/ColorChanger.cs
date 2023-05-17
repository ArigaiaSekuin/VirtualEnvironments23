using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Color startColor = Color.white;
    public Color endColor = Color.red;
    public float duration = 2f;

    private float elapsedTime = 0f;

    private void Update()
    {
        // Update the elapsed time
        elapsedTime += Time.deltaTime;

        // Calculate the current color based on the elapsed time and duration
        float t = Mathf.Clamp01(elapsedTime / duration);
        Color currentColor = Color.Lerp(startColor, endColor, t);

        // Assign the current color to the sprite renderer
        spriteRenderer.color = currentColor;

        // Check if the color transition is complete
        if (t >= 1f)
        {
            // Color transition is complete, do any necessary actions here
            Debug.Log("Color transition complete");

            // Disable this script to prevent further updates
            enabled = false;
        }
    }
}
