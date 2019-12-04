using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    // Start is called before the first frame update
    private Text scoreText;
    public float timer = 0.0f;
    public int seconds;

    void Start()
    {
        scoreText = GetComponent<Text>();
        
    }

    // Update is called once per frame
    void Update()
    {
        // seconds in float
        timer += Time.deltaTime;
        // turn seconds in float to int
        seconds = (int)(timer);
        scoreText.text = "Score: " + seconds;
        PlayerPrefs.SetInt("score", seconds);
        if(seconds > PlayerPrefs.GetInt("highScore", 0)) {
            PlayerPrefs.SetInt("highScore", seconds);
        }
    }
}
