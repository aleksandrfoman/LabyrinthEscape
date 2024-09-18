using System;
using Content.Scripts.Sounds;
using Sounds;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Content.Scripts.PlayerScripts
{
    [Serializable]
    public class PlayerSound
    {
        [SerializeField] private CharacterController characterController;
        [SerializeField] private float walkStepInterval = 0.5f;
        [SerializeField] private float sprintStepInterval = 0.3f;
        [SerializeField] private float velocityThreshold = 0.1f;
        private float nextStepTime = 0f;
        private AudioService audioService;
        private Player player;
        
        public void Init(Player player,AudioService audioService)
        {
            this.player = player;
            this.audioService = audioService;
        }
        
        public void FootSteps()
        {
            float curInterval = Input.GetKey(KeyCode.LeftShift) ? sprintStepInterval : walkStepInterval;
            if (characterController.isGrounded && Time.time > nextStepTime && 
                characterController.velocity.magnitude > velocityThreshold)
            {
                PlayStepSound();
                nextStepTime = Time.time + curInterval;
            }
        }

        private void PlayStepSound()
        {
            float pitchRnd = Random.Range(0.9f, 1.1f);
            audioService.PlayFxSound(SoundDataSO.SoundFxType.PlayerMove,player.transform.position,pitchRnd);
        }
    }
}
