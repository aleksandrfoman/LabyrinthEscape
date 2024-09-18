using Content.Scripts.PlayerScripts;
using Content.Scripts.Sounds;
using Content.Scripts.Trigger;
using DG.Tweening;
using Sounds;
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
        private AudioService audioService;
        private float curCd;
        
        [Inject]
        private void Construct(AudioService audioService)
        {
            this.audioService = audioService;
            
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
            audioService.PlayFxSound(SoundDataSO.SoundFxType.SpikeTrapShow,transform.position,1f,1f,16f);
        }

        private void HideSpike()
        {
            if(!isSpike) return;

            spikeTrigger.EnableTrigger(false);
            isSpike = false;
            spikeHeader.DOLocalMoveY(-1f, 0.55f).SetEase(Ease.Linear);
            audioService.PlayFxSound(SoundDataSO.SoundFxType.SpikeTrapHide,transform.position,1f,1f,16f);
        }

        private void SpikeHit(Player player)
        {
            if (player != null)
            {
                player.PlayerHealth.TakeDamage(1);
            }
        }
    }
}
