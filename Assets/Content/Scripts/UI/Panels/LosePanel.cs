using Content.Scripts.Services;
using UnityEngine;
using UnityEngine.UI;

namespace Content.Scripts.UI.Panels
{
    public class LosePanel : MonoBehaviour
    {
        [SerializeField] private Button restartBtn;
        [SerializeField] private Button quitBtn;

        public void Init(GameService gameService)
        {
            restartBtn.onClick.AddListener(gameService.Restart);
            quitBtn.onClick.AddListener(gameService.Quit);
        }
        public void EnablePanel(bool value)
        {
            gameObject.SetActive(value);
        }
    }
}
