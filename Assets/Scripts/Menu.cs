using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {
    public Button[] button;
    // Start is called before the first frame update
    void Start () {
        button[0].onClick.AddListener (() => OnButtonClick (0));
        button[1].onClick.AddListener (() => OnButtonClick (1));
        button[2].onClick.AddListener (() => OnButtonClick (2));
    }
    public void OnButtonClick (int id) {
        switch (id) {
            case 0:
                SaveSystem.SetInt("Load", 0);
                SceneManager.LoadScene("CharacterLevel");
                break;
            case 1:
                if (SaveSystem.GetString("Scene") != "")
                {
                    SceneManager.LoadScene(SaveSystem.GetString("Scene"));
                    SaveSystem.SetInt("Load", 1);
                }
                break;
            case 2:
                Application.Quit();
                break;
        }
    }

}