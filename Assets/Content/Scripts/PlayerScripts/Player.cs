using System;
using Content.Scripts.Services;
using UnityEngine;
namespace Content.Scripts.PlayerScripts
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private PlayerMovement playerMovement;
        [SerializeField] private PlayerSound playerSound;
        [SerializeField] private PlayerInteractive playerInteractive;

        public void Init(GameCanvasService gameCanvasService)
        {
            playerInteractive.Init(gameCanvasService);
        }
        private void Update()
        {
            playerMovement.Movement();
            playerMovement.Rotation();
            playerSound.FootSteps();
            playerInteractive.UpdateInteractive();
        }
    }
}