using UnityEngine;

namespace Content.Scripts.UI.Panels
{
    public class GamePanel : MonoBehaviour
    {
        [SerializeField] private KeyCounter keyCounter;
        [SerializeField] private GameObject pickUp;
        [SerializeField] private GameObject completeLevel;
        [SerializeField] private GameObject needKey;
        [SerializeField] private TimerCounter timerCounter;

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
