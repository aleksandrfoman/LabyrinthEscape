using UnityEngine;
namespace Content.Scripts.Sounds
{
    public class AudioSourceObject : MonoBehaviour
    {
        [SerializeField] private AudioSource audioSource;
    
        public AudioSource AudioSource => audioSource;

        public void Init(AudioClip clip, float volume,bool is3DSound,Vector3 position, float pitch,  float minDist, float maxDist)
        {
            gameObject.SetActive(true);
            transform.position = position;
            audioSource.spatialBlend = is3DSound ? 1f : 0f;
            audioSource.clip = clip;
            audioSource.volume = volume;
            audioSource.pitch = pitch;
            audioSource.minDistance = minDist;
            audioSource.maxDistance = maxDist;
            audioSource.Play();
        }

        public void Disable()
        {
            audioSource.Stop();
            audioSource.volume = 0f;
            audioSource.clip = null;
            audioSource.pitch = 1f;
            audioSource.minDistance = 1f;
            audioSource.maxDistance = 500f;
            gameObject.SetActive(false);
        }
    }
}
