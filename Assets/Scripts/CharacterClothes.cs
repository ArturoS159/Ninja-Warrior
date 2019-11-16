using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class CharacterClothes : MonoBehaviour
{
    public GameObject character;
    public GameObject[] sprite;
    public Sprite[] hoods;
    public Button[] button;

    void Start()
    {
        button[0].onClick.AddListener (() => OnButtonClick (0));
        button[1].onClick.AddListener (() => OnButtonClick (1));
    }

    public void OnButtonClick (int id) {
        
        string localPath = "Assets/Prefabs/Character.prefab";
        if(id==1)
        {
            PrefabUtility.SaveAsPrefabAsset(character, localPath);
        }  
        else
            sprite[0].GetComponent<SpriteRenderer> ().sprite=hoods[0];
    }
}
