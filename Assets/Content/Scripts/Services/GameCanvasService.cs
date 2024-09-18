using System.Collections.Generic;
using Content.Scripts.UI.Panels;
using UnityEngine;
using Zenject;

namespace Content.Scripts.Services
{
    public class GameCanvasService : MonoBehaviour
    {
        [SerializeField] private GamePanel gamePanel;
        [SerializeField] private PausePanel pausePanel;
        [SerializeField] private WinPanel winPanel;
        [SerializeField] private LosePanel losePanel;

        [Inject]
        private void Construct(GameService gameService)
        {
            pausePanel.Init(gameService);
            winPanel.Init(gameService);
            losePanel.Init(gameService);
        }
        
        public void OpenPanel(EGameState gameState)
        {
            switch (gameState)
            {
                case EGameState.Game:
                    gamePanel.EnablePanel(true);
                    pausePanel.EnablePanel(false);
                    winPanel.EnablePanel(false);
                    losePanel.EnablePanel(false);
                    break;
                case EGameState.Win:
                    gamePanel.EnablePanel(false);
                    pausePanel.EnablePanel(false);
                    winPanel.EnablePanel(true);
                    losePanel.EnablePanel(false);
                    break;
                case EGameState.Lose:
                    gamePanel.EnablePanel(false);
                    pausePanel.EnablePanel(false);
                    winPanel.EnablePanel(false);
                    losePanel.EnablePanel(true);
                    break;
                case EGameState.Pause:
                    gamePanel.EnablePanel(false);
                    pausePanel.EnablePanel(true);
                    winPanel.EnablePanel(false);
                    losePanel.EnablePanel(false);
                    break;
            }
        }

        public void CalculateWinPanel(List<string> foundKeyTimeList,string finalTime)
        {
            winPanel.CalculateFinalPanel(foundKeyTimeList,finalTime);
        }
        
        public void UpdateKeyCounter(int cur, int max)
        {
            gamePanel.UpdateKeyCounter(cur, max);
        }

        public void EnablePickUp(bool value)
        {
            gamePanel.EnablePickUp(value);
        }

        public void EnableDoorText(bool value, bool hasKey)
        {
            gamePanel.EnableDoorText(value,hasKey);
        }

        public void EnableTimerCounter(bool value)
        {
            gamePanel.EnableTimerCounter(value);
        }

        public void UpdateTimerCounter(string str)
        {
            gamePanel.UpdateTimerCounter(str);
        }
    }
}
