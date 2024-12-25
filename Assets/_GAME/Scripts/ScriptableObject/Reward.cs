using UnityEngine;


namespace CardGame
{
    [System.Serializable]
    public class Reward
    {
        public string rewardName;
        public Sprite rewardIcon;
        public int rewardValue;
        public string titleTXT;
        public string descriptionTXT;
        public float weight;
        public bool isBomb;
    }

}