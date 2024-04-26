using System;
using MixarTest1.Models;
using MixarTest1.Views;
using UnityEngine;
using VContainer.Unity;

namespace MixarTest1.Controllers
{
    public class CollectableSoundController : IInitializable, IDisposable
    {
        private readonly CollectablesModel _collectablesModel;
        private readonly AudioSource _collectSound;

        public CollectableSoundController(CollectablesModel collectablesModel, AudioSource collectSound)
        {
            _collectablesModel = collectablesModel;
            _collectSound = collectSound;
        }

        public void Initialize()
        {
            _collectablesModel.Removed += PlaySound;
        }

        public void Dispose()
        {
            _collectablesModel.Removed -= PlaySound;
        }

        private void PlaySound(CollectableView _)
        {
            _collectSound.Play();
        }
    }
}