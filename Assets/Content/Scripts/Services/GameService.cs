using UnityEngine;
using Zenject;

namespace Content.Scripts.Services
{
    public class GameService : MonoBehaviour
    {
        public EGameState GameState => gameState;
        private EGameState gameState;
        private LevelService levelService;
        private GameCanvasService gameCanvasService;
        private SceneService sceneService;
        
        [Inject]
        private void Construct(LevelService levelService, GameCanvasService gameCanvasService, SceneService sceneService)
        {
            this.levelService = levelService;
            this.gameCanvasService = gameCanvasService;
            this.sceneService = sceneService;
            
            StartGame();
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
                }
            }
        }

        public void StartGame()
        {
            gameState = EGameState.Game;
            PauseGame(false);
            levelService.Timer.ActivateTimer(true);
            Cursor.visible = false;
            
            gameCanvasService.OpenPanel(gameState);
        }
        

        public void WinGame()
        {
            gameState = EGameState.Win;
            PauseGame(true);
            Cursor.visible = true;
            
            gameCanvasService.OpenPanel(gameState);
            gameCanvasService.CalculateWinPanel(levelService.FoundKeyTimeList,levelService.Timer.GetElapsedTimeString());
        }
        
        public void LoseGame()
        {
            gameState = EGameState.Lose;
            PauseGame(true);
            Cursor.visible = true;
            
            gameCanvasService.OpenPanel(gameState);
        }
        
        private void EnablePauseGame(bool value)
        {
            Cursor.visible = value;
            gameState = value ? EGameState.Pause : EGameState.Game;
            PauseGame(value);
            gameCanvasService.OpenPanel(gameState);
        }

        private void PauseGame(bool value)
        {
            Time.timeScale = value ? 0 : 1;
        }

        #region EventButtons

        public void Back()
        {
            EnablePauseGame(false);
        }

        public void Quit()
        {
            Application.Quit();
        }
        
        public void Restart()
        {
            sceneService.LoadScene(levelService.LevelName);
        }

        #endregion
    }

    public enum EGameState
    {
        Game,
        Win,
        Lose,
        Pause
    }
}
