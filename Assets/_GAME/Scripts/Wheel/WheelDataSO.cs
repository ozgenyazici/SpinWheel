using System.Collections.Generic;
using UnityEngine;


namespace CardGame
{
    [CreateAssetMenu(fileName = "SpinWheel", menuName = "ScriptableObjects/SpinWheel", order = 1)]
    [System.Serializable]
    public class WheelDataSO : ScriptableObject
    {
        public string name;
        public Sprite zoneBg;
        public Sprite bgSprite;
        public Sprite indicatorSprite;
        public Color textColor;

    }

}