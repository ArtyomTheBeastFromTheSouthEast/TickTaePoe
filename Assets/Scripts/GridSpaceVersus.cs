using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridSpaceVersus : MonoBehaviour
{
    public Button button;
    public Text buttonText;
    public string playerSide;
    private GameControllerVersus gameControllerVersus;

    public void SetSpace()
    {
        
        {
            buttonText.text = gameControllerVersus.GetPlayerSide();
            button.interactable = false;
            gameControllerVersus.EndTurn();
        }
    }
    public void SetGameControllerReference(GameControllerVersus controller)
    {
        gameControllerVersus = controller;
    }
}
