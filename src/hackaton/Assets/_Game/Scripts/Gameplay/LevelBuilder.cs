using System;
using Cysharp.Threading.Tasks;
using Zenject;

namespace Gameplay
{
    public class LevelBuilder
    {
        private GameplayData gameplayData;
        private PlayableItemFactory factory;
        private ItemsParent itemsParent;

        [Inject]
        public LevelBuilder(GameplayData gameplayData, ItemsParent itemsParent)
        {
            this.gameplayData = gameplayData;
            this.itemsParent = itemsParent;
        }

        public async UniTask StartInstantiate()
        {
            foreach (var reference in gameplayData.CurrentSettings.ItemsForLevel)
            {
                var playableItem = await factory.Instantiate(reference);
                playableItem.transform.parent = itemsParent.Value;
                playableItem.StartMoveToCan();
                
                await UniTask.Delay(TimeSpan.FromSeconds(gameplayData.CurrentSettings.MediumDelay));
            }
        }
    }
}