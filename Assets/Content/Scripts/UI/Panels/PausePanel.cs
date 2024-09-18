using Content.Scripts.Services;
using UnityEngine;
using UnityEngine.UI;

namespace Content.Scripts.UI.Panels
{
    public class PausePanel : MonoBehaviour
    {
        [SerializeField] private Button backBtn;
        [SerializeField] private Button quitBtn;
        
        public void Init(GameService gameService)
        {
            backBtn.onClick.AddListener(gameService.Back);
            quitBtn.onClick.AddListener(gameService.Quit);
        }
        
        public void EnablePanel(bool value)
        {
            gameObject.SetActive(value);
        }
    }
}
