using Content.Scripts.PlayerScripts;
using Content.Scripts.Sounds;
using UnityEngine;
using Zenject;

namespace Content.Scripts.Services
{
    public class PlayerService : MonoBehaviour
    {
        public Player CurPlayer => curPlayer;
        [SerializeField] private Transform spawnPoint;
        [SerializeField] private Player playerPrefab;
        private Player curPlayer;

        private GameService gameService;
        private GameCanvasService gameCanvasService;
        private JoystickService joystickService;
        private AudioService audioService;
        private LevelService levelService;
        
        [Inject]
        private void Construct(GameService gameService,GameCanvasService gameCanvasService, LevelService levelService, AudioService audioService, JoystickService joystickService)
        {
            this.gameService = gameService;
            this.audioService = audioService;
            this.gameCanvasService = gameCanvasService;
            this.levelService = levelService;
            this.joystickService = joystickService;
            
            SpawnPlayer();
        }

        private void SpawnPlayer()
        {
            Player player = Instantiate(playerPrefab, spawnPoint.position,spawnPoint.rotation);
            player.Init(gameService,gameCanvasService,levelService, audioService,joystickService);
            curPlayer = player;
        }

        public void TakeKey()
        {
            curPlayer.PlayerInteractive.TakeKey();
        }

        public void OpenDoor()
        {
            curPlayer.PlayerInteractive.OpenDoor();
        }
    }
}
