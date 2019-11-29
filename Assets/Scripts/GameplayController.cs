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
    private GameplayManager gm;
    private PlayerController PC = new PlayerController();
    public Text lifeCounter;
    public Text scoreCounter;

    private int score; 
    private int lifeScore;
    private bool hasDied;



    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        lifeScore = PC.Hp;
        hasDied = false;
        lifeCounter = GameObject.Find("LifeCounter").GetComponent<Text>();
        lifeCounter.text = "x" + lifeScore;
        gm = gm.GetComponent<GameplayManager>();
    }

    void Update()
    {
       
        if (gameObject.transform.position.y < -8)
        {
            hasDied = true;
        }
        if (hasDied == true)
        {
            
             gm.Die();
        }
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
            if(lifeScore == 0)
            {
                hasDied = true;
            }
        }
        
    }

    public void IncrementScore()
    {
        score++;
        scoreCounter.text = "x" + score.ToString();
    }
    

}
