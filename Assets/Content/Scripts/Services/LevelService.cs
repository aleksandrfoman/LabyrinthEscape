using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Content.Scripts.Services
{
    public class LevelService : MonoBehaviour
    {
        public string LevelName => levelName;
        public Timer Timer => timer;
        public bool HasAllKey => curKeyCount == keys.Length;
        public List<string> FoundKeyTimeList => foundKeyTimeList;
        
        [SerializeField] private string levelName;
        [SerializeField] private Key[] keys;
        [SerializeField] private List<string> foundKeyTimeList = new List<string>();
        
        private Timer timer;
        private GameCanvasService gameCanvasService;
        private int maxKeyCount;
        private int curKeyCount;
        
        [Inject]
        private void Construct(GameCanvasService gameCanvasService)
        {
            this.gameCanvasService = gameCanvasService;

            timer = new Timer();
            
            curKeyCount = 0;
            maxKeyCount = keys.Length;
            gameCanvasService.UpdateKeyCounter(curKeyCount,maxKeyCount);
        }

        private void Update()
        {
            timer.UpdateTimer();
            gameCanvasService.UpdateTimerCounter(timer.GetElapsedTimeString());
        }

        public void TakeKey()
        {
            curKeyCount++;
            foundKeyTimeList.Add(timer.GetElapsedTimeString());
            gameCanvasService.UpdateKeyCounter(curKeyCount,maxKeyCount);
        }
    }
}
