using System;

namespace Infrastructure.Service.Input
{
    public class ButtonInputService : IInputService, IButtonInputService
    {
        public event Action<float> OnMove;

        public void MoveClick(float direction) =>
            OnMove?.Invoke(direction * 4);
    }
}