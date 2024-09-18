using System;
using Content.Scripts.PlayerScripts;
using Content.Scripts.Trigger;
using DG.Tweening;
using UnityEngine;
using Zenject;

namespace Content.Scripts
{
    public class TrapSpike : MonoBehaviour
    {
        [SerializeField] private Transform spikeHeader;
        [SerializeField] private InputTrigger spikeTrigger;
        [SerializeField] private float damage = 1;
        [SerializeField] private float changeTime;
        [SerializeField] private bool isSpike;
        private float curCd;

        [Inject]
        private void Construct()
        {
            spikeTrigger.OnInputTriggerEnter += SpikeHit;
        }
        
        private void Update()
        {
            if (curCd <= 0f)
            {
                curCd = changeTime;
                if (isSpike)
                {
                    HideSpike();
                }
                else
                {
                    ShowSpike();
                }
            }
            else
            {
                curCd -= Time.deltaTime;
            }
        }

        private void ShowSpike()
        {
            if(isSpike) return;
            
            spikeTrigger.EnableTrigger(true);
            isSpike = true;
            spikeHeader.DOLocalMoveY(0f, 0.55f).SetEase(Ease.Linear);
        }

        private void HideSpike()
        {
            if(!isSpike) return;

            spikeTrigger.EnableTrigger(false);
            isSpike = false;
            spikeHeader.DOLocalMoveY(-1f, 0.55f).SetEase(Ease.Linear);
        }

        private void SpikeHit(Player player)
        {
            
        }
    }
}
