using Content.Scripts.Services;
using Content.Scripts.SO;
using Content.Scripts.Sounds;
using DG.Tweening;
using Sounds;
using UnityEngine;
using Zenject;

namespace Content.Scripts
{
    public class Key : MonoBehaviour
    {
        public bool IsTake=> isTake;
        public string TakeTime => takeTime;
        [SerializeField] private KeySO keySO;
        [SerializeField] private Transform meshTransform;
        [SerializeField] private new Renderer renderer;
        private string takeTime;
        private bool isTake;
        private LevelService levelService;
        private AudioService audioService;
        [Inject]
        private void Construct(LevelService levelService, AudioService audioService)
        {
            this.audioService = audioService;
            this.levelService = levelService;
            
            renderer.material.color = keySO.Color;
            StartAnimation();
        }
        
        public void TakeKey()
        {
            isTake = true;
            levelService.TakeKey();
            Deactivate();
        }

        private void Deactivate()
        {
            audioService.PlayFxSound(SoundDataSO.SoundFxType.Key,transform.position);
            StopAnimation();
            transform.DOScale(Vector3.one * 0.01f, 0.75f).OnComplete(() =>
            {
                Destroy(gameObject);
            });
        }

        #region Animation

        private Tween move;
        private Tween rotate;

        private void StartAnimation()
        {
            move?.Kill();
            rotate?.Kill();

            meshTransform.localEulerAngles = Vector3.zero;
            meshTransform.localPosition = Vector3.zero;

            rotate = meshTransform.DOLocalRotate(new Vector3(0f, 360f, 0f), 4f, RotateMode.LocalAxisAdd)
                .SetEase(Ease.Linear)
                .SetLoops(-1, LoopType.Restart);
            move = meshTransform.DOLocalMoveY(0.1f, 2f)
                .SetEase(Ease.InOutSine)
                .SetLoops(-1, LoopType.Yoyo);
        }

        public void StopAnimation()
        {
            move?.Kill();
            rotate?.Kill();
        }

        #endregion
    }

    public enum EKeyType
    {
        Red,
        Blue,
        Pink,
        Orange
    }
}