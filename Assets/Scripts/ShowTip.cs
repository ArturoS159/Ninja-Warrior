using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShowTip : MonoBehaviour
{
    public int tip;
    private void OnTriggerEnter2D(Collider2D col)
    {
        switch (tip)
        {
            case 0:
                GameplayController.textW.text = "Serduszka na mapie zwiększaja Ci życie. Uważaj żeby nie spadło za dużo ☺";
                break;
            case 1:
                GameplayController.textW.text = "Score pozwala na ocene samego siebie ☺";
                break;
            case 2:
                GameplayController.textW.text = "Boosty skosku działają przez 5 sekund. Czasem trzeba być szybki ☺";
                break;
            case 3:
                GameplayController.textW.text = "Uważaj różnego rodzaju kolce/sople ranią ♥";
                break;
            case 4:
                GameplayController.textW.text = "Przedostań się na drugą strone ☺";
                break;
            case 5:
                GameplayController.textW.text = "Brawo! Teraz nauczysz się walki";
                break;
            case 6:
                GameplayController.textW.text = "Brawo właśnie w takich miejscach ukryte są dodatkowe punkty ☺";
                break;
            case 7:
                GameplayController.textW.text = "Uważaj na wieże !";
                break;
            case 8:
                GameplayController.textW.text = "Brawo to wszystko. Powodzenia w następnych poziomach ! ☺";
                break;
            case 9:
                GameplayController.textW.text = "Ciernie ranią !";
                break;
            case 10:
                GameplayController.textW.text = "Witaj przygodo. Przejdziesz teraz przez samouczek, który nauczy cię podstaw. W grze musisz zdobyć unikatową monetę.";
                break;
        }
        
    }
    private void OnTriggerExit2D(Collider2D col) 
    {
        GameplayController.textW.text = "";
    }

}
