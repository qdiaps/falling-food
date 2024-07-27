using System.Collections;
using UnityEngine;

namespace Core.Foods
{
    public class GeneratorFood : MonoBehaviour
    {
        [SerializeField] private GameObject[] _foods;
        [SerializeField] private float _positionY;
        [SerializeField] private float _minPositionX;
        [SerializeField] private float _maxPositionX;

        private void Start()
        {
            StartCoroutine(Generate());
        }

        private IEnumerator Generate()
        {
            while (true)
            {
                Vector2 position = new Vector2(Random.Range(_minPositionX, _maxPositionX), _positionY);
                int indexFood = Random.Range(0, _foods.Length);
                Instantiate(_foods[indexFood], position, Quaternion.identity);
                yield return new WaitForSeconds(1.5f);
            }
        }
    }
}