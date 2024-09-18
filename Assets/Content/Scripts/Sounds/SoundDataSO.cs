using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using Random = UnityEngine.Random;

namespace Sounds
{
    [CreateAssetMenu(fileName = "SoundDataSO", menuName = "GameData/SoundDataSO", order = 5)]

    public class SoundDataSO : ScriptableObject
    {
        public Action<SoundFxType,Vector3> OnSoundPlay;
        
        [SerializeField] private AudioMixer audioMixer;
        [SerializeField] private List<Sound> sounds = new List<Sound>();
        public List<Sound> SoundList => sounds;
        public AudioMixer AudioMixer => audioMixer;

        #if UNITY_EDITOR
        public void AssignListNames()
        {
            for (int i = 0; i < sounds.Count; i++)
            {
                sounds[i].SetName();
            }
        }
        #endif

        #region Sound
        [Serializable]
        public class Sound
        {
            [HideInInspector,SerializeField] private string name;
            [field: SerializeField] public SoundFxType SoundType { get; private set; }
            [field: SerializeField] public  bool Is3dSound { get; private set; }
            [field: SerializeField] public  bool IsDisabled { get; private set; }
            [field: SerializeField,Range(0,1f)] public float ClipVolume { get; private set; }
            
            [SerializeField] private AudioClip[] clips;
            
            public AudioClip GetAudioClip()
            {
                return clips[Random.Range(0, clips.Length)];
            }

        #if UNITY_EDITOR
            public void SetName()
            {
                name = SoundType.ToString();
            }
        #endif
        }

        public enum SoundFxType
        {
            Music = 0,
            PlayerMove = 1,
            Key = 2,
            SpikeTrapShow = 3,
            SpikeTrapHide = 4,
            PlayerHit = 5,
        }
        #endregion
    }
}
