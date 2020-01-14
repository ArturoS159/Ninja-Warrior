using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    public Button[] button;
    void Start()
    {
        button[0].onClick.AddListener(() => OnButtonClick(0));
        button[1].onClick.AddListener(() => OnButtonClick(1));
    }
    private void OnButtonClick(int id)
    {
        if (id == 0)
        {
            SceneManager.LoadScene(3);
        }else
            SceneManager.LoadScene(0);

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
