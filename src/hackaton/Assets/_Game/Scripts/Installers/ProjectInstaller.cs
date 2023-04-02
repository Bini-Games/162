using _Game.Scripts.Factories;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "ProjectInstaller", menuName = "Installers/ProjectInstaller")]
public class ProjectInstaller : ScriptableObjectInstaller<ProjectInstaller>
{
    public override void InstallBindings()
    {
        Container.Bind<GameStateMachine>().AsSingle();
        Container.Bind<StateFactory>().AsSingle();
    }
}