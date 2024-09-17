using TMPro;
using UnityEngine;
namespace Content.Scripts.UI
{
    public class KeyCounter : MonoBehaviour
    {
        [SerializeField] private TMP_Text counterText;
        public void UpdateKeyCounter(int cur, int max)
        {
            counterText.text = cur + "/" + max;
        }
    }
}
