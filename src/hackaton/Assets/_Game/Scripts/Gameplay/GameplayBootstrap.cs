using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class GameplayBootstrap : MonoBehaviour
    {
        private LevelBuilder builder;

        [Inject]
        private void Construct(LevelBuilder builder)
        {
            this.builder = builder;
        }
        
        private async UniTask Start()
        {
            builder.StartInstantiate().Forget();
        }
    }
}
