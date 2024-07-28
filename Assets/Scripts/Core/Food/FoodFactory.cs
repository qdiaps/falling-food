using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Core.Food
{
    public class FoodFactory : BaseFactory
    {
        public FoodFactory(IObjectResolver container) : base(container) { }

        public void Create(GameObject prefab, Vector3 position)
        {
            _container
                .Instantiate(prefab, position, Quaternion.identity);
        }
    }
}