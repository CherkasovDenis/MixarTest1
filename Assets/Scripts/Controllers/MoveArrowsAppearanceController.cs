using System;
using MixarTest1.Models;
using MixarTest1.Views;
using VContainer.Unity;

namespace MixarTest1.Controllers
{
    public class MoveArrowsAppearanceController : IInitializable, IDisposable
    {
        private readonly MoveArrowsView _moveArrowsView;

        private readonly MovablesModel _movablesModel;

        public MoveArrowsAppearanceController(MoveArrowsView moveArrowsView, MovablesModel movablesModel)
        {
            _moveArrowsView = moveArrowsView;
            _movablesModel = movablesModel;
        }

        public void Initialize()
        {
            _movablesModel.Added += EnableArrows;
            _movablesModel.RemovedAll += DisableArrows;
        }

        public void Dispose()
        {
            _movablesModel.Added -= EnableArrows;
            _movablesModel.RemovedAll -= DisableArrows;
        }

        private void EnableArrows(MovableView _) => _moveArrowsView.Enable();

        private void DisableArrows() => _moveArrowsView.Disable();
    }
}