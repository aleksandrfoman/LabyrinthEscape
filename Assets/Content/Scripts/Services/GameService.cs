using System;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

namespace Content.Scripts.Services
{
    public class GameService : MonoBehaviour
    {
        public EGameState GameState => gameState;
        private EGameState gameState;
        private Timer timer;
        
        [Inject]
        private void Construct()
        {
            
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                switch (gameState)
                {
                    case EGameState.Game:
                        EnablePauseGame(true);
                        break;
                    case EGameState.Pause: 
                        EnablePauseGame(false);
                        break;
                    case EGameState.Win: break;
                    case EGameState.Lose: break;
                    default: throw new ArgumentOutOfRangeException();
                }
            }
        }

        public void WinGame()
        {
            
        }
        
        public void LoseGame()
        {
            
        }
        
        private void EnablePauseGame(bool value)
        {
            if (value)
            {
                gameState = EGameState.Pause;
                Time.timeScale = 0;
            }
            else
            {
                gameState = EGameState.Game;
                Time.timeScale = 1;
            }
        }
    }

    public enum EGameState
    {
        Game,
        Win,
        Lose,
        Pause
    }
}
