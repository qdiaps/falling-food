using System;

namespace Infrastructure.Service
{
    public interface IInputService
    {
        event Action<float> OnMove;
    }
}