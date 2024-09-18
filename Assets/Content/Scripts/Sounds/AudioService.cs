using System.Collections;
using System.Collections.Generic;
using Sounds;
using UnityEngine;
namespace Content.Scripts.Sounds
{
    public class AudioService : MonoBehaviour
    {
        [Space]
        [SerializeField] private AudioSourceObject audioSourceObjectPrefab;
        [SerializeField] private SoundDataSO soundDataSO;
        [SerializeField] private AudioSource playerFxSource;
        [SerializeField] private AudioSource musicSource;
        
        private PoolMono<AudioSourceObject> audioPool;
        private Queue<AudioSourceObject> queueFx = new Queue<AudioSourceObject>(5);
        
        private void Start()
        {
            InitFxPool();
            PlayMusic();
        }

        private void InitFxPool()
        {
            audioPool = new PoolMono<AudioSourceObject>(audioSourceObjectPrefab, 1, transform);
            audioPool.isAutoExpand = true;
        }
        
        public void PlayFxSound(SoundDataSO.SoundFxType soundFxType, Vector3 position, float pitch = 1f, float minDist = 1f, float maxDist = 500f)
        {
            SoundDataSO.Sound curSound = soundDataSO.SoundList.Find(x => x.SoundType == soundFxType);
            
            if(curSound.IsDisabled) return;

            if (soundFxType == SoundDataSO.SoundFxType.PlayerMove)
            {
                playerFxSource.transform.position = position;
                playerFxSource.spatialBlend = curSound.Is3dSound ? 1f : 0f;
                playerFxSource.pitch = pitch;
                playerFxSource.clip = curSound.GetAudioClip();
                playerFxSource.volume = curSound.ClipVolume;
                playerFxSource.Play();
            }
            else
            {
                StartCoroutine(AudioPlayFx(curSound.GetAudioClip(), curSound.ClipVolume,curSound.Is3dSound,position, pitch,minDist,maxDist));
            }

        }

        private IEnumerator AudioPlayFx(AudioClip clip, float volume,bool is3DSound, Vector3 position, float pitch, float minDist, float maxDist)
        {
            AudioSourceObject poolSourceObject = audioPool.GetFreeElement();
            if (poolSourceObject == null)
            {
                AudioSourceObject sourceObject = queueFx.Dequeue();
                sourceObject.Disable();
                sourceObject.Init(clip, volume, is3DSound,position,pitch,minDist,maxDist);
                yield return new WaitForSeconds(clip.length);
                sourceObject.Disable();
            }
            else
            {
                poolSourceObject.Init(clip, volume, is3DSound,position,pitch,minDist,maxDist);
                queueFx.Enqueue(poolSourceObject);
                yield return new WaitForSeconds(clip.length);
                poolSourceObject.Disable();
                if (queueFx.Contains(poolSourceObject))
                {
                    queueFx.Dequeue();
                }
            }
        }
        
        private void PlayMusic()
        {
            SoundDataSO.Sound curSound = soundDataSO.SoundList.Find(x => x.SoundType == SoundDataSO.SoundFxType.Music);
            if (curSound == null || curSound.IsDisabled) return;
            
            musicSource.clip = curSound.GetAudioClip();
            musicSource.volume = curSound.ClipVolume;
            musicSource.Play();
        }
        
        public void ToggleVolumeFx(bool enabled)
        {
            if (enabled)
            {
                soundDataSO.AudioMixer.SetFloat("Fx", 0);
            }
            else
            {
                soundDataSO.AudioMixer.SetFloat("Fx", -80);
            }
        }
        
        public void ChangeVolumeFx(float volume)
        {
            soundDataSO.AudioMixer.SetFloat("Fx",Mathf.Lerp(-80,0,volume));
        }
        
        public void ToggleVolumeMusic(bool enabled)
        {
            if (enabled)
            {
                PlayMusic();
            }
            else
            {
                musicSource.Stop();
            }
        }
        
        public void ChangeVolumeMusic(float volume)
        {
            soundDataSO.AudioMixer.SetFloat("MusicVolume",Mathf.Lerp(-80,0,volume));
        }
    }
}
