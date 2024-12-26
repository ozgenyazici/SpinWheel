﻿using UnityEngine;
using System;
namespace CardGame
{
    [Serializable]
    public class Reward : IReward
    {
        private Sprite _icon;
        private string _name;
        private int _value;
        private int _id;
        private float _weight;

        public Sprite icon { get => _icon; set => _icon = value; }
        public string name { get => _name; set => _name = value; }
        public int value { get => _value; set => _value = value; }
        public int id { get => _id; set => _id = value; }
        public float weight { get => _weight; set => _weight = value; }
    }

}