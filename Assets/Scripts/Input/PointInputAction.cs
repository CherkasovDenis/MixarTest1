using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace MixarTest1.Input
{
    public class PointInputAction
    {
        public event Action<Vector2> Performed;

        private readonly InputAction _inputAction;

        private readonly float _threshold;

        private Vector2 _startPosition;

        public PointInputAction(InputAction inputAction, float threshold)
        {
            _inputAction = inputAction;
            _threshold = threshold;
        }

        public void Initialize()
        {
            _inputAction.started += Started;
            _inputAction.performed += TryPerform;
        }

        public void Dispose()
        {
            _inputAction.started -= Started;
            _inputAction.performed -= TryPerform;
        }

        private void Started(InputAction.CallbackContext context)
        {
            _startPosition = Pointer.current.position.ReadValue();
        }

        private void TryPerform(InputAction.CallbackContext obj)
        {
            if ((_startPosition - Pointer.current.position.ReadValue()).sqrMagnitude < _threshold)
            {
                Performed?.Invoke(_startPosition);
            }
        }
    }
}