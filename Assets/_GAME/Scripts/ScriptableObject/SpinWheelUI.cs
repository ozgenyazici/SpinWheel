using UnityEngine;
using UnityEngine.UI;

namespace CardGame
{
    public class SpinWheelUI : MonoBehaviour
    {
        [SerializeField] private Image backgroundImage;
        [SerializeField] private Image indicatorImage;

        private void OnEnable()
        {
            RewardManager.Instance.OnSpinWheelDataEvent.AddListener(UpdateSpinWheelVisuals);
        }
        private void OnDisable()
        {
            RewardManager.Instance.OnSpinWheelDataEvent.RemoveListener(UpdateSpinWheelVisuals);
        }


        void UpdateSpinWheelVisuals(SpinWheelData spinWheelData)
        {
            backgroundImage.sprite = spinWheelData.bgSprite;
            indicatorImage.sprite = spinWheelData.indicatorSprite;
        }
    }

}