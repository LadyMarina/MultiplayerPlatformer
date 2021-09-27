using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UndefinedBehaviour.MultiplayerPlatformer
{
    [RequireComponent(typeof(Button))]
    public class SimpleButtonAnimation : MonoBehaviour , IPointerEnterHandler , IPointerExitHandler
    {
        [SerializeField] private Vector2 _finalScale = new Vector2(1.2f, 1.2f);
        [SerializeField] private float _duration = 0.1f;
        [SerializeField] private Ease _ease = Ease.InOutSine;

        private Vector2 _initialScale;

        private void Awake()
        {
            _initialScale = transform.localScale;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            transform.DOScale(_finalScale, _duration).SetEase(_ease);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            transform.DOScale(_initialScale, _duration).SetEase(_ease);   
        }
    }
}
