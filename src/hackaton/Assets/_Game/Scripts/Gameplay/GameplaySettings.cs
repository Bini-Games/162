using System;
using System.Collections.Generic;
using UnityEngine.AddressableAssets;

namespace Gameplay
{
    [Serializable]
    public class GameplaySettings
    {
        public float MediumDuration;
        public float MediumDelay;
        public List<AssetReference> ItemsForLevel;
    }
}