using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterClothes : MonoBehaviour
{
    
    public GameObject character;
    public Button[] button;
    private int hoodId = 4;
    private int faceId = 4;
    private int shouldersId = 5;
    private int elbowId = 4;
    private int wristId = 4;
    private int weaponId = 5;
    private int torsoId = 5;
    private int pelvisId = 5;
    private int legsId = 0;
    private int bootsId = 4;

    void Start()
    {

        button[0].onClick.AddListener(() => OnButtonClick(0));
        button[1].onClick.AddListener(() => OnButtonClick(1));
        button[2].onClick.AddListener(() => OnButtonClick(2));
        button[3].onClick.AddListener(() => OnButtonClick(3));
        button[4].onClick.AddListener(() => OnButtonClick(4));
        button[5].onClick.AddListener(() => OnButtonClick(5));
        button[6].onClick.AddListener(() => OnButtonClick(6));
        button[7].onClick.AddListener(() => OnButtonClick(7));
        button[8].onClick.AddListener(() => OnButtonClick(8));
        button[9].onClick.AddListener(() => OnButtonClick(9));
        button[10].onClick.AddListener(() => OnButtonClick(10));
        button[11].onClick.AddListener(() => OnButtonClick(11));
        button[12].onClick.AddListener(() => OnButtonClick(12));
        button[13].onClick.AddListener(() => OnButtonClick(13));
        button[14].onClick.AddListener(() => OnButtonClick(14));
        button[15].onClick.AddListener(() => OnButtonClick(15));
        button[16].onClick.AddListener(() => OnButtonClick(16));
        button[17].onClick.AddListener(() => OnButtonClick(17));
        button[18].onClick.AddListener(() => OnButtonClick(18));
        button[19].onClick.AddListener(() => OnButtonClick(19));
        button[20].onClick.AddListener(() => OnButtonClick(20));
    }

    public void OnButtonClick (int id) {
        switch (id)
        {
            case 0:
                if (hoodId > 0)
                    hoodId--;
                character.GetComponent<CharacterWear>().changeHood(hoodId);
                break;
            case 1:
                if (hoodId < 4)
                    hoodId++;
                character.GetComponent<CharacterWear>().changeHood(hoodId);
                break;
            case 2:
                if (faceId > 0)
                    faceId--;
                character.GetComponent<CharacterWear>().changeFace(faceId);
                break;
            case 3:
                if (faceId < 4)
                    faceId++;
                character.GetComponent<CharacterWear>().changeFace(faceId);
                break;
            case 4:
                if (shouldersId > 0)
                    shouldersId--;
                character.GetComponent<CharacterWear>().changeShoulders(shouldersId);
                break;
            case 5:
                if (shouldersId < 5)
                    shouldersId++;
                character.GetComponent<CharacterWear>().changeShoulders(shouldersId);
                break;
            case 6:
                if (elbowId > 0)
                    elbowId--;
                character.GetComponent<CharacterWear>().changeElbow(elbowId);
                break;
            case 7:
                if (elbowId < 4)
                    elbowId++;
                character.GetComponent<CharacterWear>().changeElbow(elbowId);
                break;
            case 8:
                if (wristId > 0)
                    wristId--;
                character.GetComponent<CharacterWear>().changeWrist(wristId);
                break;
            case 9:
                if (wristId < 4)
                    wristId++;
                character.GetComponent<CharacterWear>().changeWrist(wristId);
                break;
            case 10:
                if (weaponId > 0)
                    weaponId--;
                character.GetComponent<CharacterWear>().changeWeapon(weaponId);
                break;
            case 11:
                if (weaponId < 5)
                    weaponId++;
                character.GetComponent<CharacterWear>().changeWeapon(weaponId);
                break;
            case 12:
                if (torsoId > 0)
                    torsoId--;
                character.GetComponent<CharacterWear>().changeTorso(torsoId);
                break;
            case 13:
                if (torsoId < 5)
                    torsoId++;
                character.GetComponent<CharacterWear>().changeTorso(torsoId);
                break;
            case 14:
                if (pelvisId > 0)
                    pelvisId--;
                character.GetComponent<CharacterWear>().changePelvis(pelvisId);
                break;
            case 15:
                if (pelvisId < 5)
                    pelvisId++;
                character.GetComponent<CharacterWear>().changePelvis(pelvisId);
                break;
            case 16:
                if (legsId > 0)
                    legsId--;
                character.GetComponent<CharacterWear>().changeLegs(legsId);
                break;
            case 17:
                if (legsId < 3)
                    legsId++;
                character.GetComponent<CharacterWear>().changeLegs(legsId);
                break;
            case 18:
                if (bootsId > 0)
                    bootsId--;
                character.GetComponent<CharacterWear>().changeBoots(bootsId);
                break;
            case 19:
                if (bootsId < 4)
                    bootsId++;
                character.GetComponent<CharacterWear>().changeBoots(bootsId);
                break;
            default:
                character.GetComponent<PlayerController>().hood = hoodId;
                character.GetComponent<PlayerController>().face = faceId;
                character.GetComponent<PlayerController>().shoulder = shouldersId;
                character.GetComponent<PlayerController>().elbow = elbowId;
                character.GetComponent<PlayerController>().wrist = wristId;
                character.GetComponent<PlayerController>().weapon = weaponId;
                character.GetComponent<PlayerController>().torso = torsoId;
                character.GetComponent<PlayerController>().pelvis = pelvisId;
                character.GetComponent<PlayerController>().leg = legsId;
                character.GetComponent<PlayerController>().boot = bootsId;
                System.IO.File.WriteAllText(Application.persistentDataPath + "/Character.json", JsonUtility.ToJson(character.GetComponent<PlayerController>()));
                SceneManager.LoadScene("Tutorial");
                break;
        }
    }


}
