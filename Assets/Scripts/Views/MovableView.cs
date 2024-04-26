using UnityEngine;

namespace MixarTest1.Views
{
    public class MovableView : View
    {
        [SerializeField]
        private MeshRenderer _meshRenderer;

        [SerializeField]
        private Color[] _colors;

        private int _currentColorIndex;

        private int _maxColorIndex;

        private void Start()
        {
            _currentColorIndex = 0;
            _maxColorIndex = _colors.Length - 1;
            _meshRenderer.material.color = _colors[_currentColorIndex];
        }

        public void ChangeColor()
        {
            _currentColorIndex++;

            if (_currentColorIndex > _maxColorIndex)
            {
                _currentColorIndex = 0;
            }

            _meshRenderer.material.color = _colors[_currentColorIndex];
        }
    }
}