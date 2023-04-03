using UnityEngine.Rendering.PostProcessing;
using Zenject;

namespace Gameplay
{
    public class GameplayInstaller : MonoInstaller
    {
        public ItemsParent Parent;
        public Can Can;
        public PostProcessProfile PostProcessProfile;
        
        public override void InstallBindings()
        {
            Container.Bind<Can>().FromInstance(Can).AsSingle();
            Container.Bind<PlayableItemFactory>().AsSingle();
            Container.Bind<ItemsParent>().FromInstance(Parent).AsSingle();
            Container.Bind<LevelBuilder>().AsSingle();
            Container.Bind<GameplayScore>().AsSingle();
            Container.BindInterfacesTo<SaturationUpdater>().AsSingle();
            Container.Bind<PostProcessProfile>().FromScriptableObject(PostProcessProfile).AsSingle();
            Container.BindInterfacesTo<GameplayArbiter>().AsSingle();
        }
    }
}