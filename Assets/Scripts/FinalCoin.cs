using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalCoin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Scene scene = SceneManager.GetActiveScene();
        if (collision.name == "Character")
        {
            if (scene.buildIndex == 5)
            {
                SaveSystem.SetInt("Hp", GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().hp);
                SaveSystem.SetInt("Score", GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().score);
                SceneManager.LoadScene(scene.buildIndex+1);
            }
            SaveSystem.SetInt("Hp", GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().hp);
            SaveSystem.SetInt("Score", GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().score);
            SceneManager.LoadScene(scene.buildIndex+1);

        }
    }
}
