using UnityEngine;
namespace CardGame
{
    public class LevelFactory : MonoBehaviour
    {
        [SerializeField] private RewardManager rewardManager;


        private const string resourcePath = "Levels";

        public Reward GetReward(string name)
        {
            Reward reward = new Reward();
            reward.icon = rewardManager.GetIcon(name);
            reward.name = rewardManager.GetName(name);
            reward.value = rewardManager.GetValue(name);

            return reward;
        }

        public LevelDataSO GetLevelData(int levelNumber)
        {
            string levelName = $"Level_{levelNumber}";
            LevelDataSO levelData = Resources.Load<LevelDataSO>($"{resourcePath}/{levelName}");

            if (levelData == null)
            {
                Debug.LogError($"LevelDataSO with name {levelName} not found in Resources/{resourcePath}");
            }

            return levelData;
        }
    }
}