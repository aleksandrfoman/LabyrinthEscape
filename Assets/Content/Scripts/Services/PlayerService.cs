using Content.Scripts.Misc;
using Content.Scripts.PlayerScripts;
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
        
        [Inject]
        private void Construct(GameCanvasService gameCanvasService)
        {
            this.gameCanvasService = gameCanvasService;
            SpawnPlayer();
        }

        private void SpawnPlayer()
        {
            Player player = Instantiate(playerPrefab, spawnPoint.position,spawnPoint.rotation);
            player.Init(gameCanvasService);
            curPlayer = player;
        }
    }
}
