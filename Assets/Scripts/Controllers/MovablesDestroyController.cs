using System;
using MixarTest1.Models;
using MixarTest1.Views;
using VContainer.Unity;
using Object = UnityEngine.Object;

namespace MixarTest1.Controllers
{
    public class MovablesDestroyController : IInitializable, IDisposable
    {
        private readonly MovablesModel _movablesModel;

        public MovablesDestroyController(MovablesModel movablesModel)
        {
            _movablesModel = movablesModel;
        }

        public void Initialize()
        {
            _movablesModel.Added += InitializeMovable;
        }

        public void Dispose()
        {
            _movablesModel.Removed -= InitializeMovable;
        }

        private void InitializeMovable(MovableView movableView)
        {
            movableView.LongTap += () => DestroyMovable(movableView);
        }

        private void DestroyMovable(MovableView movableView)
        {
            _movablesModel.Remove(movableView);

            Object.Destroy(movableView.gameObject);
        }
    }
}