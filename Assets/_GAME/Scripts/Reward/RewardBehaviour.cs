using UnityEngine;
using UnityEngine.UI;
using TMPro;
namespace CardGame
{
    public class RewardBehaviour : MonoBehaviour
    {
        [SerializeField] private Image iconRenderer;
        [SerializeField] private TextMeshProUGUI value;

        private Vector2 imageStartPos;
        private Vector2 imageStartScale;
        private Reward _data;
        public void Initialize(Reward rewardData)
        {
            this._data = rewardData;
            imageStartPos = iconRenderer.transform.localPosition;
            imageStartScale = iconRenderer.transform.localScale;

            SetIcon();
            SetName();
            SetValue();
        }
        private void SetIcon()
        {
            iconRenderer.sprite = _data.icon;
        }

        private void SetName()
        {
            transform.name = _data.name;
        }

        private void SetValue()
        {
            value.text = _data.value.ToString();
        }

        public void ResetTransform()
        {
            iconRenderer.transform.localPosition = imageStartPos;
            iconRenderer.transform.localScale = imageStartScale;
        }

    }

}