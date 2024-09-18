using TMPro;
using UnityEngine;
namespace Content.Scripts.UI
{
    public class WinKey : MonoBehaviour
    {
        [SerializeField] private TMP_Text timeText;
    
        public void Init(int keyIndex,string time)
        {
            timeText.text = $"Key {keyIndex} time"+"\n"+time;
        }
    }
}
