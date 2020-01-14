using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{

    public AudioClip walk;
    public AudioClip jump;
    public AudioClip attack1;
    public AudioClip attack2;
    public AudioClip attack3;
    public AudioClip coin;
    public AudioClip hearth;
    public AudioClip jumpbooster;
    public AudioClip orcattack;
    public AudioClip orcdeath;
    public AudioClip damage;
    public AudioClip towerShoot;

    private static AudioSource audioSource;

    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
    
    }
        

    public static void play(string val)
    {
        SoundManagerScript script = GameObject.Find("SoundManager").GetComponent<SoundManagerScript>();
        switch (val)
        {
            case "move":
                if (!audioSource.isPlaying.Equals(script.walk))
                {
                    audioSource.PlayOneShot(script.walk);
                }
                break;
            case "jump":
                audioSource.PlayOneShot(script.jump);
                break;
            case "attack1":
                audioSource.PlayOneShot(script.attack1);
                break;
            case "attack2":
                audioSource.PlayOneShot(script.attack2);
                break;
            case "attack3":
                audioSource.PlayOneShot(script.attack3);
                break;
            case "coin":
                audioSource.PlayOneShot(script.coin);
                break;
            case "hearth":
                audioSource.PlayOneShot(script.hearth);
                break;
            case "jumpbooster":
                audioSource.PlayOneShot(script.jumpbooster);
                break;
            case "orcattack":
                audioSource.PlayOneShot(script.orcattack);
                break;
            case "orcdeath":
                audioSource.PlayOneShot(script.orcdeath);
                break;
            case "damage":
                audioSource.PlayOneShot(script.damage);
                break;
            case "towerShoot":
                audioSource.PlayOneShot(script.towerShoot);
                break;

        }
        
        
        
    }

}
