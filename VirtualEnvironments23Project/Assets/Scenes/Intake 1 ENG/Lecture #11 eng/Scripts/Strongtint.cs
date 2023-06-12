using System.Collections;
using UnityEngine;

public class Strongtint : MonoBehaviour
{
    // Reference to SpriteRenderer
    public SpriteRenderer spriteRenderer;

    // Duration of the fade
    private float duration = 2.0f;

    void Start()
    {
        // Start the coroutine to fade the sprite
        StartCoroutine(Fade());
    }

    IEnumerator Fade()
    {
        // Get initial material's _StrongTintFade value
        float initialTint = spriteRenderer.material.GetFloat("_StrongTintFade");

        for (float t = 0.0f; t < duration; t += Time.deltaTime)
        {
            // Gradually change the property "_StrongTintFade" from 1 to 0
            float newTint = Mathf.Lerp(initialTint, 0, t / duration);
            spriteRenderer.material.SetFloat("_StrongTintFade", newTint);
            yield return null;
        }

        // Ensure the _StrongTintFade value is set to its final value
        spriteRenderer.material.SetFloat("_StrongTintFade", 0);
    }
}
