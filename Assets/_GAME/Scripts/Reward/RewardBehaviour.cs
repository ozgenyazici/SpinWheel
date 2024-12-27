using UnityEngine;
using UnityEngine.UI;
using TMPro;
namespace CardGame
{
    public class RewardBehaviour : MonoBehaviour
    {
        public Image iconRenderer;
        [SerializeField] private TextMeshProUGUI value;

        private Vector2 imageStartPos;
        private Vector2 imageStartScale;
        public Reward data;
        public void Initialize(Reward rewardData)
        {
            this.data = rewardData;
            imageStartPos = iconRenderer.transform.localPosition;
            imageStartScale = iconRenderer.transform.localScale;
            SetIcon();
            SetName();
            SetValue();
        }
        private void SetIcon()
        {
            iconRenderer.sprite = data.icon;
        }

        private void SetName()
        {
            transform.name = data.name;
        }

        private void SetValue()
        {
            value.text = data.value.ToString();
        }

        public void ResetTransform()
        {
            iconRenderer.transform.localPosition = imageStartPos;
            iconRenderer.transform.localScale = imageStartScale;
        }

    }

}