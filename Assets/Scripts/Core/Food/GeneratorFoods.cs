using System.Collections;
using UnityEngine;
using VContainer;

namespace Core.Food
{
    public class GeneratorFoods : MonoBehaviour, IGeneratorFoods
    {
        private FoodFactory _factory;
        private FoodConfig _foodConfig;
        private GeneratorFoodsConfig _generatorFoodsConfig;

        [Inject]
        public void Construct(FoodFactory factory, FoodConfig foodConfig, GeneratorFoodsConfig generatorFoodsConfig)
        {
            _factory = factory;
            _foodConfig = foodConfig;
            _generatorFoodsConfig = generatorFoodsConfig;
        }

        public void StartGenerator() => 
            StartCoroutine(Generate());

        private IEnumerator Generate()
        {
            while (true)
            {
                _factory.Create(GetRandomPrefab(), GetRandomPosition());
                yield return new WaitForSeconds(1f);
            }
        }

        private GameObject GetRandomPrefab()
        {
            var index = Random.Range(0, _foodConfig.Foods.Length);
            return _foodConfig.Foods[index];
        }

        private Vector3 GetRandomPosition()
        {
            var x = Random.Range(_generatorFoodsConfig.MinPositionX, _generatorFoodsConfig.MaxPositionX);
            return new Vector3(x, _generatorFoodsConfig.PositionY, 0f);
        }
    }
}