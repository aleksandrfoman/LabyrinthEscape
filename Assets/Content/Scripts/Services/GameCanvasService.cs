using Content.Scripts.UI;
using UnityEngine;
namespace Content.Scripts.Services
{
    public class GameCanvasService : MonoBehaviour
    {
        [SerializeField] private GamePanel gamePanel;

        public void UpdateKeyCounter(int cur, int max)
        {
            gamePanel.UpdateKeyCounter(cur, max);
        }

        public void EnablePickUp(bool value)
        {
            gamePanel.EnablePickUp(value);
        }
    }
}
