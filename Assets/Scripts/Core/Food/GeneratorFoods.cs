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
        private float _currentGravityScale = 0.1f;
        private float _currentSpeedGenerate = 5f;

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
                _factory.Create(GetRandomPrefab(), GetRandomPosition())
                    .GetComponent<Rigidbody2D>()
                    .gravityScale = _currentGravityScale;
                _currentGravityScale += 0.01f;
                if (_currentSpeedGenerate > 2f)
                    _currentSpeedGenerate -= 0.15f;
                yield return new WaitForSeconds(_currentSpeedGenerate);
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