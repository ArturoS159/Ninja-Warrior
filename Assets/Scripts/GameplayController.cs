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
    public Text lifeCounter;
    public Text scoreCounter;
    private int score; 
    private int lifeScore;



    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        pc = gameObject.GetComponent<PlayerController>();
        try {
            lifeScore = pc.Hp;
        }catch (NullReferenceException)
        {
            
        }
        lifeCounter = GameObject.Find("LifeCounter").GetComponent<Text>();
        lifeCounter.text = "x" + lifeScore;
    }

    public void IncrementLife()
    {
        lifeCounter = GameObject.Find("LifeCounter").GetComponent<Text>();
        lifeScore++;
        lifeCounter.text = "x" + lifeScore;

    }

    public void DecrementLife()
    {
        lifeCounter = GameObject.Find("LifeCounter").GetComponent<Text>();
        lifeScore--;
        if(lifeScore >= 0)
        {
            lifeCounter.text = "x" + lifeScore;
        }
        
    }

    public void IncrementScore()
    {
        score++;
        scoreCounter.text = "x" + score.ToString();
    }
    

}
