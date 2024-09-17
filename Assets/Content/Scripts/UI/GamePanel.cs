using UnityEngine;
namespace Content.Scripts.UI
{
    public class GamePanel : MonoBehaviour
    {
        [SerializeField] private KeyCounter keyCounter;
        [SerializeField] private GameObject pickUp;
        private bool isPickUp;
        public void UpdateKeyCounter(int cur, int max)
        {
            keyCounter.UpdateKeyCounter(cur, max);
        }
        public void EnablePickUp(bool value)
        {
            if(isPickUp == value) return;
            
            isPickUp = value;
            pickUp.gameObject.SetActive(value);
        }
    }
}
