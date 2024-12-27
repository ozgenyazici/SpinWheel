using UnityEngine;
using System;
namespace CardGame
{
    [Serializable]
    public class Reward
    {
        public int id;
        public string name;
        public Sprite icon;
        public int value;
        public bool isBomb;

    }
}