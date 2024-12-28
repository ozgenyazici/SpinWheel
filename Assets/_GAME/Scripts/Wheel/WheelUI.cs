using UnityEngine;
using UnityEngine.UI;

namespace CardGame
{
    public class WheelUI : MonoBehaviour
    {
        [SerializeField] private Image backgroundImage;
        [SerializeField] private Image wheelImage;
        [SerializeField] private Image indicatorImage;
        [SerializeField] private WheelManager wheelManager;
        private void OnEnable()
        {
            wheelManager.OnSpinWheelDataEvent.AddListener(UpdateSpinWheelVisuals);
        }
        private void OnDisable()
        {
            wheelManager.OnSpinWheelDataEvent.RemoveListener(UpdateSpinWheelVisuals);
        }


        void UpdateSpinWheelVisuals(WheelDataSO spinWheelData)
        {
            wheelImage.sprite = spinWheelData.bgSprite;
            backgroundImage.sprite = spinWheelData.zoneBg;
            indicatorImage.sprite = spinWheelData.indicatorSprite;
        }
    }
}