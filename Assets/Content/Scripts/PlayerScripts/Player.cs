using Content.Scripts.Services;
using Content.Scripts.Sounds;
using UnityEngine;
namespace Content.Scripts.PlayerScripts
{
    public class Player : MonoBehaviour
    {
        public PlayerHealth PlayerHealth => playerHealth;
        
        [SerializeField] private PlayerMovement playerMovement;
        [SerializeField] private PlayerSound playerSound;
        [SerializeField] private PlayerInteractive playerInteractive;
        [SerializeField] private PlayerHealth playerHealth;
        
        private GameService gameService;
        public void Init(GameService gameService,GameCanvasService gameCanvasService, LevelService levelService, AudioService audioService)
        {
            this.gameService = gameService;
            
            playerInteractive.Init(gameCanvasService,levelService,gameService);
            playerSound.Init(this,audioService);
            
            playerHealth.OnDead += Dead;
        }
        private void Update()
        {
            if (gameService.GameState != EGameState.Game)
                return;
            
            playerMovement.Movement();
            playerMovement.Rotation();
            playerSound.FootSteps();
            playerInteractive.UpdateInteractive();
        }

        private void Dead()
        {
            gameService.LoseGame();
        }
    }
}