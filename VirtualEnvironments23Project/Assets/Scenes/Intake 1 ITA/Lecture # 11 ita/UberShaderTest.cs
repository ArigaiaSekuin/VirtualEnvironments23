using UnityEngine;

public class UberShaderTest : MonoBehaviour
{
    SpriteRenderer rend;

    void Start()
    {
        rend = GetComponent<SpriteRenderer> ();

    }

    public void EnableRecolor()
    {
        //rend.material.shader = Shader.Find("Sprite Shaders Ultimate/Uber/Standard Uber");
        rend.material.SetFloat("_EnableRecolor", 0);
    }


}