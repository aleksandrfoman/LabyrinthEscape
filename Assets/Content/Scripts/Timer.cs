using System;
using UnityEngine;

namespace Content.Scripts
{
    [Serializable]
    public class Timer
    {
        private bool isTimer;
        private float elapsedTime;
        
        public void ActivateTimer(bool value)
        {
            isTimer = value;
        }
        
        public void UpdateTimer()
        {
            if (isTimer)
            {
                elapsedTime += Time.deltaTime;
            }
        }

        public float GetElapsedTime() => elapsedTime;
        
        public string GetElapsedTimeString()
        {
            int minutes = Mathf.FloorToInt(elapsedTime / 60);
            int seconds = Mathf.FloorToInt(elapsedTime % 60);
            return string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
}
