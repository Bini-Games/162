using Zenject;

namespace _Game.Scripts.Factories
{
    public class StateFactory
    {
        private DiContainer container;

        public StateFactory(DiContainer container) => 
            this.container = container;

        public IState Create<T>() where T : IState
        {
            return container.Instantiate(typeof(T)) as IState;
        }
    }
}