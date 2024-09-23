using System;
using Content.Scripts.PlayerScripts;
using Content.Scripts.Services;
using UnityEngine;
using UnityEngine.UI;

namespace Content.Scripts.UI.Panels
{
    public class GamePanel : MonoBehaviour
    {
        [SerializeField] private KeyCounter keyCounter;
        [SerializeField] private GameObject pickUp;
        [SerializeField] private GameObject completeLevel;
        [SerializeField] private Button btnPickUp;
        [SerializeField] private Button btnCompleteLevel;
        [SerializeField] private GameObject needKey;
        [SerializeField] private TimerCounter timerCounter;

        public void Init(PlayerService playerService)
        {
            btnPickUp.onClick.AddListener(playerService.TakeKey);
            btnCompleteLevel.onClick.AddListener(playerService.OpenDoor);
        }

        public void OnDestroy()
        {
            btnPickUp.onClick.RemoveAllListeners();
            btnCompleteLevel.onClick.RemoveAllListeners();
        }

        public void EnablePanel(bool value)
        {
            gameObject.SetActive(value);
        }
        
        public void UpdateKeyCounter(int cur, int max)
        {
            keyCounter.UpdateKeyCounter(cur, max);
        }

        public void EnableTimerCounter(bool value)
        {
            timerCounter.EnableTimer(value);
        }

        public void UpdateTimerCounter(string str)
        {
            timerCounter.UpdateTextCounter(str);
        }
        
        public void EnablePickUp(bool value)
        {
            pickUp.gameObject.SetActive(value);
        }

        public void EnableDoorText(bool value, bool hasKey)
        {
            if (value)
            {
                if (hasKey)
                {
                    completeLevel.gameObject.SetActive(true);
                    needKey.gameObject.SetActive(false);
                }
                else
                {
                    completeLevel.gameObject.SetActive(false);
                    needKey.gameObject.SetActive(true);
                }
            }
            else
            {
                completeLevel.gameObject.SetActive(false);
                needKey.gameObject.SetActive(false);
            }
        }
    }
}
