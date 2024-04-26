using System;
using MixarTest1.Factories;
using MixarTest1.Models;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using VContainer.Unity;

namespace MixarTest1.Controllers
{
    public class MovablesSpawnController : IInitializable, IDisposable
    {
        private readonly MovablesModel _movablesModel;
        private readonly InputModel _inputModel;
        private readonly MovablesFactory _factory;

        public MovablesSpawnController(MovablesModel movablesModel, InputModel inputModel,
            MovablesFactory factory)
        {
            _movablesModel = movablesModel;
            _inputModel = inputModel;
            _factory = factory;
        }

        public void Initialize()
        {
            _inputModel.TapOnPlane += Spawn;
        }

        public void Dispose()
        {
            _inputModel.TapOnPlane -= Spawn;
        }

        private void Spawn(ARPlane arPlane, Vector3 position)
        {
            _movablesModel.Add(_factory.Create(arPlane, position));
        }
    }
}