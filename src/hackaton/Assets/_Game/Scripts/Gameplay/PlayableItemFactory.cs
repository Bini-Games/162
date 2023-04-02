using Cysharp.Threading.Tasks;
using UnityEngine.AddressableAssets;
using Zenject;

namespace Gameplay
{
    public class PlayableItemFactory
    {
        private GameplayData gameplayData;
        private DiContainer diContainer;

        [Inject]
        public PlayableItemFactory(GameplayData gameplayData, DiContainer diContainer)
        {
            this.gameplayData = gameplayData;
            this.diContainer = diContainer;
        }

        public async UniTask<PlayableItem> Instantiate(AssetReference assetReference)
        {
            var item = await Addressables.InstantiateAsync(assetReference);
            diContainer.InjectGameObject(item);
            item.transform.position = gameplayData.GetRandomPosition();

            return item.GetComponent<PlayableItem>();
        }
    }
}