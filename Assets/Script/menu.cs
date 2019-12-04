using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menu : MonoBehaviour {
    
    public Text hsValue;
    public Text scoreValue;

    void Start () {
        hsValue.text = PlayerPrefs.GetInt("highScore", 0).ToString();
        scoreValue.text = PlayerPrefs.GetInt("score").ToString();
    }

    public void playGame () {
        SceneManager.LoadScene("sampleScene");
    }

    public void returnMenu() {
        SceneManager.LoadScene("Menu");
    }

    public void loadCredits() {
        SceneManager.LoadScene("credits");
    }

    public void exitGame() {
        Application.Quit();
    }
}
