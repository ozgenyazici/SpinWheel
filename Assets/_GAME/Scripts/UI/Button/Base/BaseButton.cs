using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
namespace CardGame
{
    public abstract class BaseButton : MonoBehaviour, IButton
    {
        public event Action OnButtonClicked;

        public TextMeshProUGUI Text { get => text; set => text = value; }
        public Button Button { get => button; set => button = value; }


        [SerializeField] private TextMeshProUGUI text;
        [SerializeField] private Button button;

        private bool isAnimating = false;
        private const float animDuration = .1f;
        private void OnValidate()
        {
            text = GetComponentInChildren<TextMeshProUGUI>();
            button = GetComponent<Button>();
        }
        private void OnEnable()
        {
            GetComponent<Button>().onClick.AddListener(HandleClick);
        }
        private void OnDisable()
        {
            GetComponent<Button>().onClick.RemoveListener(HandleClick);
        }

        public void HandleClick()
        {
            if (isAnimating)
                return;

            OnButtonClicked?.Invoke();
            AnimateButton();

        }

        private void AnimateButton()
        {
            Vector2 maxScale = new Vector2(.8f, .8f);
            Vector2 originalScale = transform.localScale;

            isAnimating = true;

            Sequence sequence = DOTween.Sequence();
            sequence.SetAutoKill(true);

            sequence.Append(button.transform.DOScale(maxScale, animDuration).SetEase(Ease.OutQuad)).
                Append(button.transform.DOScale(originalScale, animDuration).SetEase(Ease.OutQuad)).
                OnComplete(() => isAnimating = false);


        }
    }

}