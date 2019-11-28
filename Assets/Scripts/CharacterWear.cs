using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CharacterWear : MonoBehaviour
{
    public Sprite[] hoods;
    public Sprite[] faces;
    public Sprite[] shouldersL;
    public Sprite[] shouldersR;
    public Sprite[] elbowsL;
    public Sprite[] elbowsR;
    public Sprite[] wristsL;
    public Sprite[] wristsR;
    public Sprite[] weapons;
    public Sprite[] torsos;
    public Sprite[] pelvises;
    public Sprite[] legsL;
    public Sprite[] legsR;
    public Sprite[] bootsL;
    public Sprite[] bootsR;
    public int hood;
    public int face;
    public int shoulder;
    public int elbow;
    public int wrist;
    public int weapon;
    public int torso;
    public int pelvis;
    public int leg;
    public int boot;

    internal void changeHood(int i)
    {
        GameObject.FindGameObjectWithTag("Hood").GetComponent<SpriteRenderer>().sprite = hoods[i];
    }
    internal void changeFace(int i)
    {
        GameObject.FindGameObjectWithTag("Face").GetComponent<SpriteRenderer>().sprite = faces[i];
    }
    internal void changeShoulders(int i)
    {
        GameObject.FindGameObjectWithTag("ShoulderL").GetComponent<SpriteRenderer>().sprite = shouldersL[i];
        GameObject.FindGameObjectWithTag("ShoulderR").GetComponent<SpriteRenderer>().sprite = shouldersR[i];
    }
    internal void changeElbow(int i)
    {
        Debug.Log("asfasfasfasfasfasf");
        GameObject.FindGameObjectWithTag("ElbowL").GetComponent<SpriteRenderer>().sprite = elbowsL[i];
        GameObject.FindGameObjectWithTag("ElbowR").GetComponent<SpriteRenderer>().sprite = elbowsR[i];
    }
    internal void changeWrist(int i)
    {
        GameObject.FindGameObjectWithTag("WristL").GetComponent<SpriteRenderer>().sprite = wristsL[i];
        GameObject.FindGameObjectWithTag("WristR").GetComponent<SpriteRenderer>().sprite = wristsR[i];
    }
    internal void changeWeapon(int i)
    {
        GameObject.FindGameObjectWithTag("WeaponL").GetComponent<SpriteRenderer>().sprite = weapons[i];
        GameObject.FindGameObjectWithTag("WeaponR").GetComponent<SpriteRenderer>().sprite = weapons[i];
    }
    internal void changeTorso(int i)
    {
        GameObject.FindGameObjectWithTag("Torso").GetComponent<SpriteRenderer>().sprite = torsos[i];
    }
    internal void changePelvis(int i)
    {
        GameObject.FindGameObjectWithTag("Pelvis").GetComponent<SpriteRenderer>().sprite = pelvises[i];
    }
    internal void changeLegs(int i)
    {
        GameObject.FindGameObjectWithTag("LegL").GetComponent<SpriteRenderer>().sprite = legsL[i];
        GameObject.FindGameObjectWithTag("LegR").GetComponent<SpriteRenderer>().sprite = legsR[i];
    }
    internal void changeBoots(int i)
    {
        GameObject.FindGameObjectWithTag("BootL").GetComponent<SpriteRenderer>().sprite = bootsL[i];
        GameObject.FindGameObjectWithTag("BootR").GetComponent<SpriteRenderer>().sprite = bootsR[i];
    }
    internal void loadWear()
    {
        string path = Application.persistentDataPath + "/Character.json";
        string jsonString = File.ReadAllText(path);
        JsonUtility.FromJsonOverwrite(jsonString, this);
        changeHood(hood);
        changeFace(face);
        changeShoulders(shoulder);
        changeElbow(elbow);
        changeWrist(wrist);
        changeWeapon(weapon);
        changeTorso(torso);
        changePelvis(pelvis);
        changeLegs(leg);
        changeBoots(boot);
    }
}
