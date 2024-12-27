using UnityEngine;
using System;
using DG.Tweening;
using UnityEngine.UI;
namespace CardGame
{
    public class GamePopupUI : MonoBehaviour
    {
        public event Action GiveUpButtonPressed;
        public event Action ReviveButtonPressed;


        [SerializeField] private CanvasGroup _canvasGroup;

        [SerializeField] private Button _giveUpButton;
        [SerializeField] private Button _reviveButton;


        private void OnEnable()
        {

        }
        private void OnDisable()
        {

        }
        public void Show(bool state)
        {
            _canvasGroup.interactable = state;
            _canvasGroup.blocksRaycasts = state;
            _canvasGroup.DOFade(state ? 1f : 0f, 0.6f).SetEase(Ease.InOutSine);
        }

    }

}