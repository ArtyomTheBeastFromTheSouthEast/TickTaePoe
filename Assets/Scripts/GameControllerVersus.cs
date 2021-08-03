using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

    [System.Serializable]
    public class Player1
    {
        public Image panel;
        public Text text;
        public Button button;
    }
    [System.Serializable]
    public class PlayerColor1
    {
        public Color panelcolor;
        public Color textcolor;
    }

    public class GameControllerVersus : MonoBehaviour
    {
        public Text[] buttonList;
        private string playerSide;
        
        public GameObject GameOverPanel;
        public Text GameOverText;
        private int MoveCount;
        public GameObject RestartButton;

        public Player playerX;
        public Player playerO;
        public PlayerColor activePlayerColor;
        public PlayerColor inactivePlayerColor;
        public GameObject StartInfo;


        private void Awake()
        {
            GameOverPanel.SetActive(false);
            SetGameControllerReferenceOnButtons();

            MoveCount = 0;
            RestartButton.SetActive(false);
            

        }
        

        void SetGameControllerReferenceOnButtons()
        {
            for (int i = 0; i < buttonList.Length; i++)
            {
                buttonList[i].GetComponentInParent<GridSpaceVersus>().SetGameControllerReference(this);
            }

        }
        public void SetStartingSide(string startingSide)
        {
            playerSide = startingSide;
            if (playerSide == "X")
            {
                
                SetPlayerColors(playerX, playerO);
            }
            else
            {
                
                SetPlayerColors(playerO, playerX);
            }
            StartGame();
        }
        void StartGame()
        {
            SetBoardInteractable(true);
            SetPlayerButtons(false);
            StartInfo.SetActive(false);

        }
        public string GetPlayerSide()
        {
            return playerSide;
        }
        
        public void EndTurn()
        {
            MoveCount++;



            if (buttonList[1].text == playerSide && buttonList[2].text == playerSide && buttonList[3].text == playerSide)
            {
                GameOver(playerSide);

            }
            else if (buttonList[4].text == playerSide && buttonList[0].text == playerSide && buttonList[5].text == playerSide)
            {
                GameOver(playerSide);

            }
            else if (buttonList[6].text == playerSide && buttonList[7].text == playerSide && buttonList[8].text == playerSide)
            {
                GameOver(playerSide);

            }
            else if (buttonList[1].text == playerSide && buttonList[4].text == playerSide && buttonList[6].text == playerSide)
            {
                GameOver(playerSide);

            }
            else if (buttonList[2].text == playerSide && buttonList[0].text == playerSide && buttonList[7].text == playerSide)
            {
                GameOver(playerSide);

            }
            else if (buttonList[3].text == playerSide && buttonList[5].text == playerSide && buttonList[8].text == playerSide)
            {
                GameOver(playerSide);

            }
            else if (buttonList[1].text == playerSide && buttonList[0].text == playerSide && buttonList[8].text == playerSide)
            {
                GameOver(playerSide);

            }

            else if (buttonList[3].text == playerSide && buttonList[0].text == playerSide && buttonList[6].text == playerSide)
            {
                GameOver(playerSide);






            }
            






            
            else if (MoveCount >= 9)
            {

                GameOver("Draw");
            }
            else
            {
                ChangeSides();
                

            }


        }
        void SetPlayerColors(Player newPlayer, Player oldPlayer)
        {
            newPlayer.panel.color = activePlayerColor.panelcolor;
            newPlayer.text.color = activePlayerColor.textcolor;
            oldPlayer.panel.color = inactivePlayerColor.panelcolor;
            oldPlayer.text.color = inactivePlayerColor.textcolor;

        }
        void GameOver(string WinningPlayer)
        {
            SetBoardInteractable(false);

            if (WinningPlayer == "Draw")
            {
                SetGameOverText("It's a Draw!");
                SetPlayerColorsInactive();
            }
            else
            {
                SetGameOverText(WinningPlayer + "Wins!");
            }
            RestartButton.SetActive(true);
        }
        void ChangeSides()
        {
            playerSide = (playerSide == "X") ? "O" : "X";
            
            if (playerSide == "X")
                
                {
                    SetPlayerColors(playerX, playerO);

                }
                else
                {
                    SetPlayerColors(playerO, playerX);

                }
        }
        void SetGameOverText(string value)
        {
            GameOverPanel.SetActive(true);
            GameOverText.text = value;
        }
        public void RestartGame()
        {

            MoveCount = 0;
            GameOverPanel.SetActive(false);
            RestartButton.SetActive(false);
            SetPlayerButtons(true);
            SetPlayerColorsInactive();
            StartInfo.SetActive(true);
            

            for (int i = 0; i < buttonList.Length; i++)
            {

                buttonList[i].text = " ";
            }
            RestartButton.SetActive(false);

        }

        void SetBoardInteractable(bool toggle)
        {
            for (int i = 0; i < buttonList.Length; i++)
            {
                buttonList[i].GetComponentInParent<Button>().interactable = toggle;
            }


        }
        void SetPlayerButtons(bool toggle)
        {
            playerX.button.interactable = toggle;
            playerO.button.interactable = toggle;

        }
        void SetPlayerColorsInactive()
        {
            playerX.panel.color = inactivePlayerColor.panelcolor;
            playerX.panel.color = inactivePlayerColor.textcolor;
            playerO.panel.color = inactivePlayerColor.panelcolor;
            playerO.panel.color = inactivePlayerColor.textcolor;

        }
    }



