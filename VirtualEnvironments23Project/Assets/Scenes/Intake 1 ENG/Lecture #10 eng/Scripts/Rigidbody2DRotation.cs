using UnityEngine;

// Rotate rigidBody2D every frame.  Start at 45 degrees.

public class Rigidbody2DRotation : MonoBehaviour
{
    public Rigidbody2D rigidBody2D;

    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        rigidBody2D.rotation = 45f;
    }

    void FixedUpdate()
    {
        rigidBody2D.rotation += 1.0f;
    }
}