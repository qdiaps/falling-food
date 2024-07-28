using System;
using UnityEngine;

namespace Infrastructure.Service
{
    public class EditorInputService : MonoBehaviour, IInputService
    {
        public event Action<float> OnMove;
    }
}