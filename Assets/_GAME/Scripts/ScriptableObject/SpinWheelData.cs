using System.Collections.Generic;
using UnityEngine;


namespace CardGame
{
    [CreateAssetMenu(fileName = "SpinWheel", menuName = "ScriptableObjects/SpinWheel", order = 1)]
    public class SpinWheelData : ScriptableObject
    {
        public Sprite bgSprite;
        public Sprite indicatorSprite;
        public List<Reward> rewards;

        bool bombAdded = false;

    }

}