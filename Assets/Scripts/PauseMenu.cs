using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    public Button[] button;
    void Start()
    {
        button[0].onClick.AddListener(() => OnButtonClick(0));
        button[1].onClick.AddListener(() => OnButtonClick(1));
    }
    public void OnButtonClick(int id)
    {
        switch (id)
        {
            case 0:
                GameObject player = GameObject.FindGameObjectWithTag("Player");
                SaveSystem.SetVector3("PlayerPos",player.GetComponent<PlayerController>().playerPosition);
                SaveSystem.SetInt("Health", player.GetComponent<PlayerController>().hp);
                SaveSystem.SetInt("Scorre", player.GetComponent<PlayerController>().score);
                SaveSystem.SetString("Scene", player.GetComponent<PlayerController>().sceneName);
                break;
            case 1:
                Application.Quit();
                break;
            case 2:
                Application.Quit();
                break;
        }
    }
}
