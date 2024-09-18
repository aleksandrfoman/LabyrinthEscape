using TMPro;
using UnityEngine;
namespace Content.Scripts.UI
{
    public class TimerCounter : MonoBehaviour
    {
        [SerializeField] private TMP_Text textCounter;
        
        public void EnableTimer(bool value)
        {
            gameObject.SetActive(value);
        }

        public void UpdateTextCounter(string str)
        {
            textCounter.text = str;
        }
    }
}
