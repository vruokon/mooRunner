using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class highScore : MonoBehaviour
{
   
    private Text hsValue;
    

    void Start()
    {
        
        hsValue.text = PlayerPrefs.GetInt("highScore", 0).ToString();
    }
}