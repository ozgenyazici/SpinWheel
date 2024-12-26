using UnityEngine;


namespace CardGame
{
    [CreateAssetMenu(fileName = "Reward", menuName = "ScriptableObjects/Reward", order = 2)]
    [System.Serializable]
    public class RewardDataSO : ScriptableObject
    {
        public int id = 0;
        public string name = "None";
        public Sprite icon;
        public float weight;
        public int value = 0;
    }
}