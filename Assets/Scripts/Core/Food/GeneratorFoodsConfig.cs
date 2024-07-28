using UnityEngine;

namespace Core.Food
{
    [CreateAssetMenu(fileName="NewGeneratorFoodsConfig", menuName="Configs/Food/GeneratorFoodsConfig")]
    public class GeneratorFoodsConfig : ScriptableObject
    {
        public float MinPositionX;
        public float MaxPositionX;
        public float PositionY;
    }
}