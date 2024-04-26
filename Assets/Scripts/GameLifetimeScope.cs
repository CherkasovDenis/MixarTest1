using MixarTest1.Configs;
using MixarTest1.Controllers;
using MixarTest1.Factories;
using MixarTest1.Models;
using MixarTest1.Views;
using TMPro;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using VContainer;
using VContainer.Unity;

namespace MixarTest1
{
    public class GameLifetimeScope : LifetimeScope
    {
        [SerializeField]
        private Camera _camera;

        [SerializeField]
        private ARRaycastManager _arRaycastManager;

        [SerializeField]
        private ARTrackedImageManager _arTrackedImageManager;

        [SerializeField]
        private MoveArrowsView _moveArrowsView;

        [SerializeField]
        private AudioSource _collectSound;

        [SerializeField]
        private TMP_Text _scoreText;

        [SerializeField]
        private MoveSpeedConfig _moveSpeedConfig;

        [SerializeField]
        private MarkerConfig _markerConfig;

        [SerializeField]
        private CollectablesSpawnConfig _collectablesSpawnConfig;

        [SerializeField]
        private MovableView _movablePrefab;

        [SerializeField]
        private CollectableView _collectableView;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(_camera);
            builder.RegisterInstance(_arRaycastManager);
            builder.RegisterInstance(_arTrackedImageManager);
            builder.RegisterInstance(_moveArrowsView);
            builder.RegisterInstance(_moveSpeedConfig);
            builder.RegisterInstance(_markerConfig);
            builder.RegisterInstance(_collectablesSpawnConfig);
            builder.RegisterInstance(_movablePrefab);
            builder.RegisterInstance(_collectableView);

            builder.Register<InputModel>(Lifetime.Scoped);
            builder.Register<MovablesModel>(Lifetime.Scoped);
            builder.Register<CollectablesModel>(Lifetime.Scoped);
            builder.Register<TrackedImageModel>(Lifetime.Scoped);
            builder.Register<MarkerModel>(Lifetime.Scoped);
            builder.Register<ScoreModel>(Lifetime.Scoped);

            builder.Register<MovablesFactory>(Lifetime.Scoped);
            builder.Register<CollectablesFactory>(Lifetime.Scoped);

            builder.RegisterEntryPoint<InputController>(Lifetime.Scoped);
            builder.RegisterEntryPoint<MovablesSpawnController>(Lifetime.Scoped);
            builder.RegisterEntryPoint<MoveArrowsAppearanceController>(Lifetime.Scoped);
            builder.RegisterEntryPoint<MovablesMoveController>(Lifetime.Scoped);
            builder.RegisterEntryPoint<MovablesChangeColorController>(Lifetime.Scoped);
            builder.RegisterEntryPoint<MovablesDestroyController>(Lifetime.Scoped);
            builder.RegisterEntryPoint<CollectablesSpawnController>(Lifetime.Scoped);
            builder.RegisterEntryPoint<CollectablesCollectController>(Lifetime.Scoped);
            builder.RegisterEntryPoint<CollectableSoundController>(Lifetime.Scoped).WithParameter(_collectSound);
            builder.RegisterEntryPoint<TrackedImageController>(Lifetime.Scoped);
            builder.RegisterEntryPoint<MarkerDownloadController>(Lifetime.Scoped);
            builder.RegisterEntryPoint<ScoreController>(Lifetime.Scoped).WithParameter(_scoreText);
        }
    }
}