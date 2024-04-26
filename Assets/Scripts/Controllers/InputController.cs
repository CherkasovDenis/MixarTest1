using System;
using System.Collections.Generic;
using MixarTest1.Input;
using MixarTest1.Models;
using MixarTest1.Views;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using VContainer.Unity;

namespace MixarTest1.Controllers
{
    public class InputController : IInitializable, IDisposable
    {
        private readonly ARRaycastManager _arRaycastManager;
        private readonly InputModel _inputModel;
        private readonly Camera _camera;

        private Controls _controls;

        private PointInputAction _tap;

        private PointInputAction _longTap;

        private const float Threshold = 0.001f;

        public InputController(ARRaycastManager arRaycastManager, InputModel inputModel, Camera camera)
        {
            _arRaycastManager = arRaycastManager;
            _inputModel = inputModel;
            _camera = camera;
        }

        public void Initialize()
        {
            _controls = new Controls();
            _controls.Touch.Enable();

            _tap = new PointInputAction(_controls.Touch.Tap, Threshold);
            _longTap = new PointInputAction(_controls.Touch.LongTap, Threshold);

            _tap.Initialize();
            _longTap.Initialize();

            _tap.Performed += Tap;
            _longTap.Performed += LongTap;
        }

        public void Dispose()
        {
            _tap.Dispose();
            _longTap.Dispose();

            _tap.Performed -= Tap;
            _longTap.Performed -= LongTap;
        }

        private void Tap(Vector2 tapPosition)
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }

            if (CheckRaycastOnView(tapPosition, out var view))
            {
                view.OnTap();
                return;
            }

            var hits = new List<ARRaycastHit>();

            if (_arRaycastManager.Raycast(tapPosition, hits, TrackableType.PlaneWithinPolygon))
            {
                var closestArHit = hits[0];

                var arPlane = closestArHit.trackable as ARPlane;

                _inputModel.OnTapOnPlane(arPlane, closestArHit.pose.position);
            }
        }

        private void LongTap(Vector2 tapPosition)
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }

            if (CheckRaycastOnView(tapPosition, out var view))
            {
                view.OnLongTap();
            }
        }

        private bool CheckRaycastOnView(Vector2 tapPosition, out View view)
        {
            var ray = _camera.ScreenPointToRay(tapPosition);

            if (Physics.Raycast(ray, out var raycastHit))
            {
                if (raycastHit.transform.TryGetComponent(out view))
                {
                    return true;
                }
            }

            view = null;
            return false;
        }
    }
}