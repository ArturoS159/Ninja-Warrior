using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameplayController : MonoBehaviour
{
    public static GameplayController instance;
    private PlayerController pc;
    public static Text lifeCounter;
    public static Text scoreCounter;
    public static Text textW;



    void Awake()
    {
        lifeCounter = GameObject.Find("LifeCounter").GetComponent<Text>();
        scoreCounter = GameObject.Find("CoinCounter").GetComponent<Text>();
        textW = GameObject.Find("TextW").GetComponent<Text>();
    }

    private void Start()
    {
        lifeCounter.text = "x" + 4;
        scoreCounter.text = "x" + 0;
    }

}
