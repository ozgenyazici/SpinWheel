using System;
using UnityEngine;
using TMPro;
namespace CardGame
{
    public class GoldCounter : MonoBehaviour
    {
        public event Action OnRemove;

        [Header("View")]
        [SerializeField] private Gold gold;
        [SerializeField] private TextMeshProUGUI _goldText;
        private void Awake()
        {
            gold.OnGoldChanged += GoldChanged;

            gold.currentGold = 100;

        }
        private void OnDestroy()
        {
            gold.OnGoldChanged -= GoldChanged;
        }
        private void GoldChanged()
        {
            UpdateView();
        }
        public void OnRemoveGold(int amount)
        {
            gold?.RemoveCoin(amount);
            OnRemove?.Invoke();
        }
        public void UpdateView()
        {
            if (gold == null) return;

            _goldText.text = gold.currentGold.ToString();

        }

    }
}