using System;
using MixarTest1.Models;
using MixarTest1.Views;
using VContainer.Unity;
using Object = UnityEngine.Object;

namespace MixarTest1.Controllers
{
    public class CollectablesCollectController : IInitializable, IDisposable
    {
        private readonly CollectablesModel _collectablesModel;
        private readonly ScoreModel _scoreModel;

        public CollectablesCollectController(CollectablesModel collectablesModel, ScoreModel scoreModel)
        {
            _collectablesModel = collectablesModel;
            _scoreModel = scoreModel;
        }

        public void Initialize()
        {
            _collectablesModel.Added += InitializeCollectable;
        }

        public void Dispose()
        {
            _collectablesModel.Added -= InitializeCollectable;
        }

        private void InitializeCollectable(CollectableView collectableView)
        {
            collectableView.Triggered += () => Collect(collectableView);
        }

        private void Collect(CollectableView collectableView)
        {
            _scoreModel.IncreaseScore();

            _collectablesModel.Remove(collectableView);

            Object.Destroy(collectableView.gameObject);
        }
    }
}