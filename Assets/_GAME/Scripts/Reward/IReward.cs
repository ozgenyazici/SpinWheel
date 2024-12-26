using UnityEngine;
namespace CardGame
{
    public interface IReward
    {
        public Sprite icon { get; set; }
        public string name { get; set; }

        public int value { get; set; }
        public int id { get; set; }

        public float weight { get; set; }

    }

}