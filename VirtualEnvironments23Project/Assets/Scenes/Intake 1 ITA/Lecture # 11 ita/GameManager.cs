using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    
    public bool RedBool = false;
    public bool YellowBool = false;
    public bool BlueBool = false;

    public UnityEvent FinalEvent;



//Bool Switch public methods
    public void RedBoolTrue(){

        RedBool = true;
        
    }

    public void YellowBoolTrue(){

        YellowBool = true;
        
    }
    
        public void BlueBoolTrue(){

        BlueBool = true;
        
    }

//Final Bools check method

    public void BoolsCheck(){

        Debug.Log("Bools Check Active");

        if (RedBool && YellowBool && BlueBool == true){

            FinalEvent.Invoke();

            Debug.Log("Final Event Active");

        }

        //SceneManager.LoadScene(currentSceneIndex);
    } 
}
