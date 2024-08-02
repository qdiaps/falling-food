using Infrastructure.Factory;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Core.Food
{
    public class FoodFactory : BaseFactory
    {
        public FoodFactory(IObjectResolver container) : base(container) { }

        public GameObject Create(GameObject prefab, Vector3 position)
        {
            return _container
                .Instantiate(prefab, position, Quaternion.identity);
        }
    }
}