using System;

namespace Infrastructure.Service.Input
{
    public interface IInputService
    {
        event Action<float> OnMove;
    }
}