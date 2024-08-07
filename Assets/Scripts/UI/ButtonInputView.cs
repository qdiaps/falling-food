using Infrastructure.Service.Input;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace UI
{
    public class ButtonInputView : MonoBehaviour
    {
        [SerializeField] private Button _left;
        [SerializeField] private Button _right;
        
        private IButtonInputService _inputService;

        [Inject]
        public void Construct(IButtonInputService inputService)
        {
            _inputService = inputService;
            InitButton();
        }

        private void InitButton()
        {
            _left.onClick.AddListener(() => { _inputService.MoveClick(-1); });
            _right.onClick.AddListener(() => { _inputService.MoveClick(1); });
        }
    }
}