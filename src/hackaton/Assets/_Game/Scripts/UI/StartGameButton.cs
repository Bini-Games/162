using _Game.Scripts.Data;
using Zenject;

namespace _Game.Scripts.UI
{
    class StartGameButton : UIButton
    {
        private SceneLoader sceneLoader;
        
        [Inject]
        private void Construct(SceneLoader sceneLoader) => 
            this.sceneLoader = sceneLoader;

        protected override void OnClick() => 
            sceneLoader.LoadSceneWith(Constants.GamePlayScene);
    }
}