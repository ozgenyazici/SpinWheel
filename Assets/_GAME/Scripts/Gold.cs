using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
namespace CardGame
{
    public class Gold : MonoBehaviour
    {
        public event Action OnGoldChanged;

        private const int _minGold = 0;

        private int _currentGold;


        public int currentGold { get => _currentGold; set => _currentGold = Mathf.Max(value, _minGold); }
        public int minGold => minGold;


        public void AddGold(int amount)
        {
            _currentGold += amount;
            UpdateGold();
        }
        public void RemoveCoin(int amount)
        {
            _currentGold -= amount;

            UpdateGold();
        }
        public void UpdateGold()
        {
            OnGoldChanged?.Invoke();
        }
    }
}