using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Gameplay
{
    public class GameplayBootstrap : MonoBehaviour
    {
        private LevelBuilder builder;
        
        private async UniTask Start()
        {
            builder.StartInstantiate().Forget();
        }
    }
}
