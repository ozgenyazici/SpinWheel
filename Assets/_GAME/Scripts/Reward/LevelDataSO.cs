using UnityEngine;
using System.Collections.Generic;

namespace CardGame
{
    [CreateAssetMenu(fileName = "Level", menuName = "ScriptableObjects/Level", order = 3)]
    public class LevelDataSO : ScriptableObject
    {
        public WheelDataSO wheelData;
        public List<Reward> rewards;

    }
}