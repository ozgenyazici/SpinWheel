using UnityEngine;
using System;
using DG.Tweening;
namespace CardGame
{
    public class GamePopupUI : MonoBehaviour
    {
        public event Action GiveUpButtonPressed;
        public event Action ReviveButtonPressed;


        [SerializeField] private CanvasGroup _canvasGroup;

        [SerializeField] private BaseButton _giveUpButton;
        [SerializeField] private BaseButton _reviveButton;

        private const float animDuration = 0.3f;

        private void OnEnable()
        {
            _giveUpButton.OnButtonClicked += OnGiveUpButtonClicked;
            _reviveButton.OnButtonClicked += OnReviveButtonClicked;

        }
        private void OnDisable()
        {
            _giveUpButton.OnButtonClicked -= OnGiveUpButtonClicked;
            _reviveButton.OnButtonClicked -= OnReviveButtonClicked;
        }

        private void OnGiveUpButtonClicked()
        {
            GiveUpButtonPressed?.Invoke();
        }
        private void OnReviveButtonClicked()
        {
            ReviveButtonPressed?.Invoke();
        }
        public void Show(bool state)
        {
            _canvasGroup.interactable = state;
            _canvasGroup.blocksRaycasts = state;
            _canvasGroup.DOFade(state ? 1f : 0f, animDuration).SetEase(Ease.InOutSine);
        }

    }

}