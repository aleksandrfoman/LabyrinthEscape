using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Content.Scripts.PlayerScripts
{
    [Serializable]
    public class PlayerSound
    {
        [SerializeField] private CharacterController characterController;
        [SerializeField] private AudioSource footstepSource;
        [SerializeField] private AudioClip[] audioStepClips;
        [SerializeField] private float walkStepInterval = 0.5f;
        [SerializeField] private float sprintStepInterval = 0.3f;
        [SerializeField] private float velocityThreshold = 0.1f;
        private float nextStepTime = 0f;
        
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
            int rnd = Random.Range(0, audioStepClips.Length);
            footstepSource.clip = audioStepClips[rnd];
            footstepSource.pitch = Random.Range(0.9f, 1.1f);
            footstepSource.Play();
        }
    }
}
