using System.Collections.Generic;
using Content.Scripts.Services;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Content.Scripts.UI.Panels
{
    public class WinPanel : MonoBehaviour
    {
        [SerializeField] private Button restartBtn;
        [SerializeField] private Button quitBtn;
        [SerializeField] private TMP_Text winTimeText;
        [SerializeField] private WinKey winKeyPrefab;
        [SerializeField] private Transform keyParent;
        
        public void Init(GameService gameService)
        {
            restartBtn.onClick.AddListener(gameService.Restart);
            quitBtn.onClick.AddListener(gameService.Quit);
        }
        
        public void EnablePanel(bool value)
        {
            gameObject.SetActive(value);
        }

        public void CalculateFinalPanel(List<string> foundKeyTimeList,string finalTime)
        {
            winTimeText.text = "Final Time"+"\n"+ finalTime;
            for (int i = 0; i < foundKeyTimeList.Count; i++)
            {
                WinKey curKey = Instantiate(winKeyPrefab, Vector3.zero, Quaternion.identity, keyParent);
                curKey.Init(i+1,foundKeyTimeList[i]);
            }
        }
    }
}
