using System.Collections.Generic;
using UnityEngine;


namespace CardGame
{
    [CreateAssetMenu(fileName = "SpinWheel", menuName = "ScriptableObjects/SpinWheel", order = 1)]
    public class WheelDataSO : ScriptableObject
    {
        public Sprite bgSprite;
        public Sprite indicatorSprite;
        public List<RewardDataSO> rewards;
    }

}