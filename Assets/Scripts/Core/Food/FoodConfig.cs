using UnityEngine;

namespace Core.Food
{
    [CreateAssetMenu(fileName="NewFoodConfig", menuName="Configs/Food/FoodConfig")]
    public class FoodConfig : ScriptableObject
    {
        public GameObject[] Foods;
    }
}