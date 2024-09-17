using UnityEngine;
using Zenject;

namespace Content.Scripts.Services
{
    public class LevelService : MonoBehaviour
    {
        [SerializeField] private Key[] keys;
        private GameCanvasService gameCanvasService;
        private int maxKeyCount;
        private int curKeyCount;
        
        [Inject]
        private void Construct(GameCanvasService gameCanvasService)
        {
            this.gameCanvasService = gameCanvasService;

            curKeyCount = 0;
            maxKeyCount = keys.Length;
            
            gameCanvasService.UpdateKeyCounter(curKeyCount,maxKeyCount);
        }
        
        public void TakeKey()
        {
            curKeyCount++;
            gameCanvasService.UpdateKeyCounter(curKeyCount,maxKeyCount);
        }
    }
}
