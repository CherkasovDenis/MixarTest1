using MixarTest1.Configs;
using MixarTest1.Models;
using MixarTest1.Views;
using UnityEngine;
using VContainer.Unity;

namespace MixarTest1.Controllers
{
    public class MovablesMoveController : ITickable
    {
        private readonly MovablesModel _movablesModel;
        private readonly MoveArrowsView _moveArrowsView;
        private readonly TrackedImageModel _trackedImageModel;
        private readonly MoveSpeedConfig _moveSpeedConfig;
        private readonly Vector2 _defaultMoveValue;

        public MovablesMoveController(MovablesModel movablesModel, MoveArrowsView moveArrowsView,
            TrackedImageModel trackedImageModel, MoveSpeedConfig moveSpeedConfig)
        {
            _movablesModel = movablesModel;
            _moveArrowsView = moveArrowsView;
            _defaultMoveValue = Vector2.zero;
            _trackedImageModel = trackedImageModel;
            _moveSpeedConfig = moveSpeedConfig;
        }

        public void Tick()
        {
            var moveDirection = _moveArrowsView.ResultDirection;

            if (moveDirection == _defaultMoveValue)
            {
                return;
            }

            var moveValue = new Vector3(moveDirection.x, 0, moveDirection.y)
                            * _moveSpeedConfig.MoveSpeed * Time.deltaTime;

            if (_trackedImageModel.IsTrackingImage)
            {
                moveValue *= _moveSpeedConfig.TrackedImageMoveSpeedMultiplier;
            }

            foreach (var movableView in _movablesModel.Views)
            {
                movableView.transform.Translate(moveValue);
            }
        }
    }
}