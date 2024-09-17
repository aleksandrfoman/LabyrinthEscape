using System;
using Content.Scripts.Services;
using Unity.VisualScripting;
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
        public void Init(GameCanvasService gameCanvasService)
        {
            cameraMain = Camera.main;
            this.gameCanvasService = gameCanvasService;
        }
        public void UpdateInteractive()
        {
            if (Physics.Raycast(cameraMain.transform.position,cameraMain.transform.forward,out RaycastHit hit,rayDist,interactiveLayer))
            {
                CheckKey(hit);
            }
            else
            {
                gameCanvasService.EnablePickUp(false);
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
