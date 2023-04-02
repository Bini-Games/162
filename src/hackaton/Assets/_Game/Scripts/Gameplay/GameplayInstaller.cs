using Zenject;

namespace Gameplay
{
    public class GameplayInstaller : MonoInstaller
    {
        public ItemsParent Parent;
        public Can Can;
        
        public override void InstallBindings()
        {
            Container.Bind<Can>().FromInstance(Can).AsSingle();
            Container.Bind<PlayableItemFactory>().AsSingle();
            Container.Bind<ItemsParent>().FromInstance(Parent).AsSingle();
            Container.Bind<LevelBuilder>().AsSingle();
        }
    }
}