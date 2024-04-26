using System;
using MixarTest1.Models;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using VContainer.Unity;

namespace MixarTest1.Controllers
{
    public class TrackedImageController : IInitializable, IDisposable
    {
        private readonly TrackedImageModel _trackedImageModel;
        private readonly ARTrackedImageManager _arTrackedImageManager;
        private readonly MarkerModel _markerModel;

        public TrackedImageController(TrackedImageModel trackedImageModel, ARTrackedImageManager arTrackedImageManager,
            MarkerModel markerModel)
        {
            _trackedImageModel = trackedImageModel;
            _arTrackedImageManager = arTrackedImageManager;
            _markerModel = markerModel;
        }

        public void Initialize()
        {
            _arTrackedImageManager.trackedImagesChanged += OnChanged;
            _markerModel.UpdatedTexture += UpdateTextureInLibrary;
        }

        public void Dispose()
        {
            _arTrackedImageManager.trackedImagesChanged -= OnChanged;
            _markerModel.UpdatedTexture -= UpdateTextureInLibrary;
        }

        private void OnChanged(ARTrackedImagesChangedEventArgs eventArgs)
        {
            _trackedImageModel.IsTrackingImage = true;
        }

        private void UpdateTextureInLibrary()
        {
            var library = _arTrackedImageManager.CreateRuntimeLibrary();

            _arTrackedImageManager.referenceLibrary = library;

            if (_arTrackedImageManager.referenceLibrary is MutableRuntimeReferenceImageLibrary mutableLibrary)
            {
                mutableLibrary.ScheduleAddImageWithValidationJob(_markerModel.MarkerTexture,
                    Constants.MarkerName, Constants.MarkerSize);

                _arTrackedImageManager.enabled = true;
            }
        }
    }
}