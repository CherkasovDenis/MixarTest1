using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MixarTest1.Views
{
    public class MoveArrowButtonView : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public event Action<Vector2> Pressed;

        public event Action<Vector2> Released;

        [SerializeField]
        private Vector2 _direction;

        public void OnPointerDown(PointerEventData eventData)
        {
            Pressed?.Invoke(_direction);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            Released?.Invoke(_direction);
        }
    }
}