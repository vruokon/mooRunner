﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour {
    
    public void playGame () {
        SceneManager.LoadScene("sampleScene");
    }

    public void returnMenu() {
        SceneManager.LoadScene("Menu");
    }

    public void loadCredits() {
        SceneManager.LoadScene("credits");
    }

}