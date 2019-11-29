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
                SceneManager.LoadScene("CharacterLevel");
                break;
            case 1:
                Debug.Log("LOADGAME");
                break;
            case 2:
                Application.Quit();
                break;
        }
    }

}