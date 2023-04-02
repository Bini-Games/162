using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    [CreateAssetMenu(fileName = nameof(GameplayData), menuName = "Game/Gameplay/" + nameof(GameplayData))]
    public class GameplayData : ScriptableObject
    {
        public Vector2 MaxPosition;
        public Vector2 MinPosition;
        public List<GameplaySettings> LevelSettings;

        public GameplaySettings CurrentSettings => LevelSettings[CurrentLevel];

        public int CurrentLevel;

        public Vector2 GetRandomPosition()
        {
            var xPos = Random.Range(MinPosition.x, MaxPosition.x);
            var yPos = Random.Range(MinPosition.y, MaxPosition.y);

            xPos = xPos * Random.value > 0.5f ? 1 : -1;

            return new Vector2(xPos, yPos);
        }
    }
}