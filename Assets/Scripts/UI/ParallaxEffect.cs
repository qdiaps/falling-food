using UnityEngine;

namespace UI
{
    public class ParallaxEffect : MonoBehaviour
    {
        [SerializeField, Range(0f, 1f)] private float _speed;

        private void FixedUpdate() => 
            transform.position += new Vector3(_speed * Time.deltaTime, 0f);
    }
}