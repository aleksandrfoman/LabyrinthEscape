using Content.Scripts.Misc;
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
        private GameCanvasService gameCanvasService;
        private AudioService audioService;
        
        [Inject]
        private void Construct(GameCanvasService gameCanvasService, AudioService audioService)
        {
            this.audioService = audioService;
            this.gameCanvasService = gameCanvasService;
            SpawnPlayer();
        }

        private void SpawnPlayer()
        {
            Player player = Instantiate(playerPrefab, spawnPoint.position,spawnPoint.rotation);
            player.Init(gameCanvasService, audioService);
            curPlayer = player;
        }
    }
}
