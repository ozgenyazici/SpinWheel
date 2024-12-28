using UnityEngine;
using UnityEngine.UI;
using TMPro;
namespace CardGame
{
    public class RewardBehaviour : MonoBehaviour
    {
        public SpriteRenderer spriteRenderer;
        [SerializeField] private TextMeshProUGUI value;

        private Vector2 imageStartScale;
        public Reward data;
        public void Initialize(Reward rewardData)
        {
            this.data = rewardData;
            imageStartScale = spriteRenderer.transform.localScale;
            SetIcon();
            SetName();
            SetValue();
        }
        private void SetIcon()
        {
            spriteRenderer.sprite = data.icon;
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
            spriteRenderer.transform.localScale = imageStartScale;
        }

    }

}