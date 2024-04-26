using MixarTest1.Views;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using Object = UnityEngine.Object;

namespace MixarTest1.Factories
{
    public class ViewFactory<T> where T : View
    {
        private readonly T _viewPrefab;
        private readonly Transform _cameraTransform;

        protected ViewFactory(T viewPrefab, Camera camera)
        {
            _viewPrefab = viewPrefab;
            _cameraTransform = camera.transform;
        }

        public T Create(ARPlane arPlane, Vector3 position)
        {
            var view = Object.Instantiate(_viewPrefab);

            var viewTransform = view.transform;
            var arPlaneTransform = arPlane.transform;

            viewTransform.position = position;

            var viewPosition = position;
            var planePosition = arPlaneTransform.position;

            var planeNormal = arPlane.normal;

            var rotation = Quaternion.FromToRotation(viewTransform.up, planeNormal);
            viewTransform.rotation = rotation;

            if (arPlane.alignment.IsHorizontal())
            {
                viewPosition = new Vector3(viewPosition.x, planePosition.y, viewPosition.z);
                rotation *= Quaternion.FromToRotation(viewTransform.forward,
                    Vector3.ProjectOnPlane(_cameraTransform.up, planeNormal));
            }

            if (arPlane.alignment.IsVertical())
            {
                viewPosition = new Vector3(planePosition.x, viewPosition.y, viewPosition.z);
                rotation *= Quaternion.FromToRotation(viewTransform.up,
                    Vector3.ProjectOnPlane(_cameraTransform.right, planeNormal));
            }

            viewTransform.position = viewPosition;
            viewTransform.rotation = rotation;

            view.SetARPlane(arPlane);

            return view;
        }
    }

    public class MovablesFactory : ViewFactory<MovableView>
    {
        public MovablesFactory(MovableView viewPrefab, Camera camera) : base(viewPrefab, camera) { }
    }

    public class CollectablesFactory : ViewFactory<CollectableView>
    {
        public CollectablesFactory(CollectableView viewPrefab, Camera camera) : base(viewPrefab, camera) { }
    }
}