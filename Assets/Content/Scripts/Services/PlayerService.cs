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
        
        [Inject]
        private void Construct()
        {
            SpawnPlayer();
        }

        private void SpawnPlayer()
        {
            Player player = Instantiate(playerPrefab, spawnPoint.position,spawnPoint.rotation);
            curPlayer = player;
        }
    }
}
