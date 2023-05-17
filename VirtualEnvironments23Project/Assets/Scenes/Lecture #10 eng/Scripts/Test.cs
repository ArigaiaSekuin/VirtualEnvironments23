using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Test : MonoBehaviour
{

    //Simple Variable Types
    public int MyInt;
    public float MyFloat;
    public string Mystring;
    public bool MyBool;

    //Composite Variable Types - composed of multiple simple types
    public Vector2 MyVector2;
    public Vector3 MyVector3;
    public Color MyColor;

    //Reference Variable Types - hold reference to other Game Object Components
    public Camera MyCamera;
    public Rigidbody2D MyRigidbody2D;
    public SpriteRenderer MySpriteRenderer;

    // Start is called before the first frame update
    public void Start()
    {
        MyInt = 100;
        MyFloat = 12983621.245f;
        Mystring = "Heeeeeeeeyyyyy, Now we are coding!";
    }

    // Update is called once per frame
    void Update()
    {
        MyInt = MyInt + 1;   
        Mystring = "24";
    }
}
