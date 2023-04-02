using Zenject;

namespace Gameplay
{
    public class GameplayInstaller : MonoInstaller
    {
        public Can Can;
        
        public override void InstallBindings()
        {
            Container.Bind<Can>().FromInstance(Can).AsSingle();
            Container.Bind<PlayableItemFactory>().AsSingle();
        }
    }
}