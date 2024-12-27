using System.Collections.Generic;
using System;
using UnityEngine;
namespace CardGame
{
    public class Player
    {
        private Dictionary<string, int> collectedRewards = new Dictionary<string, int>();


        public void ResetRewards()
        {

            collectedRewards.Clear();
        }
        public void ClaimRewards(Dictionary<string, int> rewards)
        {

            foreach (var i in rewards)
            {
                Debug.Log($"Rewards {i.Key}_{i.Value}");
            }

            SaveRewards(rewards);
        }

        private void SaveRewards(Dictionary<string, int> rewards)
        {
            //    string json = JsonConvert.SerializeObject(collectedRewards);

            //PlayerPrefs.SetString("collectedRewards", json);
            //PlayerPrefs.Save();
        }



    }

}