using Content.Scripts.SO;
using DG.Tweening;
using UnityEngine;

namespace Content.Scripts
{
    public class Key : MonoBehaviour
    {
        public bool IsTake=> isTake;
        [SerializeField] private KeySO keySO;
        [SerializeField] private Transform meshTransform;
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private new Renderer renderer;
        private bool isTake;
        private void Awake()
        {
            renderer.material.color = keySO.Color;
            StartAnimation();
        }

        public void TakeKey()
        {
            audioSource.Play();
            isTake = true;
            StopAnimation();
            meshTransform.DOScale(Vector3.one * 0.01f, 0.75f).OnComplete(() =>
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