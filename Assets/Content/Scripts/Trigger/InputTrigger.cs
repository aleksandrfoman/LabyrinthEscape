using System;
using Content.Scripts.PlayerScripts;
using UnityEngine;

namespace Content.Scripts.Trigger
{
    [RequireComponent(typeof(BoxCollider))]
    public class InputTrigger : MonoBehaviour
    {
        public event Action<Player> OnInputTriggerStay;
        public event Action<Player> OnInputTriggerEnter;
        public event Action OnInputTriggerExit;
        
        private bool isInTrigger;
        private Player curPlayer;

        public void EnableTrigger(bool value)
        {
            gameObject.SetActive(value);
        }
        
        private void OnTriggerEnter(Collider other)
        {
            var player = other.GetComponent<Player>();

            if (player!=null)
            {
                isInTrigger = true;
                curPlayer = player;
                OnInputTriggerEnter?.Invoke(curPlayer);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            var player = other.GetComponent<Player>();
        
            if (player!=null)
            {
                isInTrigger = false;
                curPlayer = null;
                OnInputTriggerExit?.Invoke();
            }
        }

        private void Update()
        {
            if (isInTrigger)
            {
                OnInputTriggerStay?.Invoke(curPlayer);
            }
        }
        
    }
}
