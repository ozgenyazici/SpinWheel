using UnityEngine;
using UnityEngine.UI;

namespace CardGame
{
    public class WheelUI : MonoBehaviour
    {
        [SerializeField] private Image backgroundImage;
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
            backgroundImage.sprite = spinWheelData.bgSprite;
            indicatorImage.sprite = spinWheelData.indicatorSprite;
        }
    }
}