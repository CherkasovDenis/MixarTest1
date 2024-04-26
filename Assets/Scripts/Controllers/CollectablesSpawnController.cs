using System;
using MixarTest1.Configs;
using MixarTest1.Factories;
using MixarTest1.Models;
using MixarTest1.Views;
using VContainer.Unity;
using Random = UnityEngine.Random;

namespace MixarTest1.Controllers
{
    public class CollectablesSpawnController : IInitializable, IDisposable
    {
        private readonly CollectablesSpawnConfig _collectablesSpawnConfig;
        private readonly CollectablesModel _collectablesModel;
        private readonly MovablesModel _movablesModel;
        private readonly CollectablesFactory _factory;

        public CollectablesSpawnController(CollectablesSpawnConfig collectablesSpawnConfig,
            CollectablesModel collectablesModel, MovablesModel movablesModel, CollectablesFactory factory)
        {
            _collectablesSpawnConfig = collectablesSpawnConfig;
            _collectablesModel = collectablesModel;
            _movablesModel = movablesModel;
            _factory = factory;
        }

        public void Initialize()
        {
            _movablesModel.Added += SpawnCollectables;
        }

        public void Dispose()
        {
            _movablesModel.Added -= SpawnCollectables;
        }

        private void SpawnCollectables(MovableView movableView)
        {
            var arPlane = movableView.ARPlane;

            var spawnRadiusRange = _collectablesSpawnConfig.SpawnRadiusRange;

            var collectablesCount =
                Random.Range(_collectablesSpawnConfig.MinSpawnCount, _collectablesSpawnConfig.MaxSpawnCount);

            for (var i = 0; i < collectablesCount; i++)
            {
                _collectablesModel.Add(_factory.Create(arPlane,
                    Random.insideUnitSphere.normalized * Random.Range(spawnRadiusRange.x, spawnRadiusRange.y)));
            }
        }
    }
}