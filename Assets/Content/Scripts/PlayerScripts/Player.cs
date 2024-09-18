using System;
using Content.Scripts.Services;
using Content.Scripts.Sounds;
using UnityEngine;
namespace Content.Scripts.PlayerScripts
{
    public class Player : MonoBehaviour
    {
        public bool IsDead => isDead;
        public PlayerHealth PlayerHealth => playerHealth;
        
        [SerializeField] private PlayerMovement playerMovement;
        [SerializeField] private PlayerSound playerSound;
        [SerializeField] private PlayerInteractive playerInteractive;
        [SerializeField] private PlayerHealth playerHealth;
        
        private bool isDead;
        private GameCanvasService gameCanvasService;
        public void Init(GameCanvasService gameCanvasService, AudioService audioService)
        {
            this.gameCanvasService = gameCanvasService;
            
            playerInteractive.Init(gameCanvasService);
            playerSound.Init(this,audioService);
            
            playerHealth.OnDead += Dead;
        }
        private void Update()
        {
            if (isDead) return;
            
            playerMovement.Movement();
            playerMovement.Rotation();
            playerSound.FootSteps();
            playerInteractive.UpdateInteractive();
        }

        private void Dead()
        {
            isDead = true;
        }
    }
}