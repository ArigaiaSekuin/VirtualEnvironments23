using UnityEngine;

public class Test10 : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private bool playerPassedThrough = false;

    public int MyInt;
    public Vector3 MyVector3;
    public Color MyColor;

    public GameObject MyGameObject;
    public SpriteRenderer MySprite;

    
    private void Start()
    {
        //spriteRenderer = GetComponent<SpriteRenderer>();

        MyInt = 3;
        MyVector3 = new Vector3(3,5,6);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*
        if (collision.CompareTag("Player") && !playerPassedThrough)
        {
            spriteRenderer.color = Color.red;
            playerPassedThrough = true;
        }
        */
    }

    private void Update(){

        MyMethod();
    
    }


    public void MyMethod(){
        MyInt = MyInt + 1;
    }

}
