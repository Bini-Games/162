using System;
using System.Collections.Generic;

namespace Gameplay
{
    [Serializable]
    public class GameplaySettings
    {
        public float MediumDuration;
        public float MediumDelay;
        public List<PlayableItem> ItemsForLevel;
    }
}