using UnityEngine;
namespace Content.Scripts.Sounds
{
    public class AudioSourceObject : MonoBehaviour
    {
        [SerializeField] private AudioSource audioSource;
    
        public AudioSource AudioSource => audioSource;

        public void Init(AudioClip clip, float volume,bool is3DSound,Vector3 position, float pitch)
        {
            gameObject.SetActive(true);
            transform.position = position;
            audioSource.spatialBlend = is3DSound ? 1f : 0f;
            audioSource.clip = clip;
            audioSource.volume = volume;
            audioSource.pitch = pitch;
            audioSource.Play();
        }

        public void Disable()
        {
            audioSource.Stop();
            audioSource.volume = 0f;
            audioSource.clip = null;
            audioSource.pitch = 1f;
            gameObject.SetActive(false);
        }
    }
}
