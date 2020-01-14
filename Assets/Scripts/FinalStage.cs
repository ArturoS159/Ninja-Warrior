using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinalStage : MonoBehaviour
{
    // Start is called before the first frame update
    public Text score;
    public Text hp;
    public Button main;
    void Start()
    {
        score.text = SaveSystem.GetInt("Score") + "/34";
        hp.text = SaveSystem.GetInt("Hp") + "";
        main.onClick.AddListener(() => OnButtonClick());
    }

    private void OnButtonClick()
    {
        SceneManager.LoadScene(0);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
