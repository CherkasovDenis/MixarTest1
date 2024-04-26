using System;
using MixarTest1.Models;
using MixarTest1.Views;
using VContainer.Unity;

namespace MixarTest1.Controllers
{
    public class MovablesChangeColorController : IInitializable, IDisposable
    {
        private readonly MovablesModel _movablesModel;

        public MovablesChangeColorController(MovablesModel movablesModel)
        {
            _movablesModel = movablesModel;
        }

        public void Initialize()
        {
            _movablesModel.Added += InitializeMovable;
            _movablesModel.Removed += DisposeMovable;
        }

        public void Dispose()
        {
            foreach (var movableView in _movablesModel.Views)
            {
                DisposeMovable(movableView);
            }
        }

        private void InitializeMovable(MovableView movableView)
        {
            movableView.Tap += movableView.ChangeColor;
        }

        private void DisposeMovable(MovableView movableView)
        {
            movableView.Tap -= movableView.ChangeColor;
        }
    }
}