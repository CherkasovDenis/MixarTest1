using System.Collections.Generic;
using UnityEngine;

namespace MixarTest1.Views
{
    public class MoveArrowsView : MonoBehaviour
    {
        public Vector2 ResultDirection => _resultDirection;

        [SerializeField]
        private List<MoveArrowButtonView> _arrows;

        private Vector2 _resultDirection;

        private void Start()
        {
            foreach (var moveArrowButtonView in _arrows)
            {
                moveArrowButtonView.Pressed += ArrowPressed;
                moveArrowButtonView.Released += ArrowReleased;
            }
        }

        private void OnDestroy()
        {
            foreach (var moveArrowButtonView in _arrows)
            {
                moveArrowButtonView.Pressed -= ArrowPressed;
                moveArrowButtonView.Released -= ArrowReleased;
            }
        }

        public void Enable()
        {
            gameObject.SetActive(true);
        }

        public void Disable()
        {
            gameObject.SetActive(false);
        }

        private void ArrowPressed(Vector2 direction)
        {
            _resultDirection += direction;
        }

        private void ArrowReleased(Vector2 direction)
        {
            _resultDirection -= direction;
        }
    }
}