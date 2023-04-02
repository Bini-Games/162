using _Game.Scripts.Factories;
using Gameplay;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "ProjectInstaller", menuName = "Installers/ProjectInstaller")]
public class ProjectInstaller : ScriptableObjectInstaller<ProjectInstaller>
{
    public GameplayData GameplayData;
    
    public override void InstallBindings()
    {
        Container.Bind<GameplayData>().FromScriptableObject(GameplayData).AsSingle();
        Container.Bind<GameStateMachine>().AsSingle();
        Container.Bind<StateFactory>().AsSingle();
    }
}