using System;
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
        
        public void Init()
        {
            cameraMain = Camera.main;
        }
        public void UpdateInteractive()
        {
            if (Physics.Raycast(cameraMain.transform.position,cameraMain.transform.forward,out RaycastHit hit,rayDist,interactiveLayer))
            {
                Key curKey = hit.transform.GetComponent<Key>();
                if (curKey != null)
                {
                    if (Input.GetKeyDown(KeyCode.E) && !curKey.IsTake)
                    {
                        curKey.TakeKey();
                    }
                }
            }
        } 
    }
}
