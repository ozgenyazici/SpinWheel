using UnityEngine;
using UnityEngine.UI;

namespace CardGame
{
    public class WheelUI : MonoBehaviour
    {
        [SerializeField] private Image backgroundImage;
        [SerializeField] private Image indicatorImage;
        [SerializeField] private RewardManager rewardManager;
        private void OnEnable()
        {
            rewardManager.OnSpinWheelDataEvent.AddListener(UpdateSpinWheelVisuals);
        }
        private void OnDisable()
        {
            rewardManager.OnSpinWheelDataEvent.RemoveListener(UpdateSpinWheelVisuals);
        }


        void UpdateSpinWheelVisuals(WheelDataSO spinWheelData)
        {
            backgroundImage.sprite = spinWheelData.bgSprite;
            indicatorImage.sprite = spinWheelData.indicatorSprite;
        }
    }

}