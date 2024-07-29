using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Core.Player
{
    public class PlayerFactory : BaseFactory
    {
        private const string Player = "Core/Player";
        
        public PlayerFactory(IObjectResolver container) : base(container) { }

        public GameObject Create()
        {
            return _container
                .Instantiate(Resources.Load<GameObject>(Player));
        }
    }
}