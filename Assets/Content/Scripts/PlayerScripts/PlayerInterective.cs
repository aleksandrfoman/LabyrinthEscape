using System;
using Content.Scripts.Services;
using UnityEngine;
namespace Content.Scripts.PlayerScripts
{
    [Serializable]
    public class PlayerInteractive
    {
        [SerializeField] private float rayDist = 2f;
        [SerializeField] private LayerMask interactiveLayer;
        private Camera cameraMain;
        private GameCanvasService gameCanvasService;
        private LevelService levelService;
        private GameService gameService;
        public void Init(GameCanvasService gameCanvasService,LevelService levelService, GameService gameService)
        {
            cameraMain = Camera.main;
            this.gameCanvasService = gameCanvasService;
            this.levelService = levelService;
            this.gameService = gameService;
        }
        public void UpdateInteractive()
        {
            if (Physics.Raycast(cameraMain.transform.position,cameraMain.transform.forward,out RaycastHit hit,rayDist,interactiveLayer))
            {
                CheckKey(hit);
                CheckDoor(hit);
            }
            else
            {
                gameCanvasService.EnablePickUp(false);
                gameCanvasService.EnableDoorText(false,false);
            }
        }

        private void CheckDoor(RaycastHit hit)
        {
            Door curDoor = hit.transform.GetComponent<Door>();
            if (curDoor != null)
            {
                gameCanvasService.EnableDoorText(true,levelService.HasAllKey);
                if (Input.GetKeyDown(KeyCode.E) && levelService.HasAllKey)
                {
                    gameCanvasService.EnableDoorText(false,false);
                    gameService.WinGame();
                }
            }
            else
            {
                gameCanvasService.EnableDoorText(false,false);
            }
        }
        private void CheckKey(RaycastHit hit)
        {
            Key curKey = hit.transform.GetComponent<Key>();
            if (curKey != null && !curKey.IsTake)
            {
                gameCanvasService.EnablePickUp(true);
                    
                if (Input.GetKeyDown(KeyCode.E))
                {
                    curKey.TakeKey();
                }
            }
            else
            {
                gameCanvasService.EnablePickUp(false);
            }
        }
    }
}
