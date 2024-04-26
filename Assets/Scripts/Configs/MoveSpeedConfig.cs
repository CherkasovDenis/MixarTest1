using UnityEngine;

namespace MixarTest1.Configs
{
    [CreateAssetMenu(fileName = nameof(MoveSpeedConfig), menuName = Constants.ConfigMenuPath + nameof(MoveSpeedConfig))]
    public class MoveSpeedConfig : ScriptableObject
    {
        public float MoveSpeed => _moveSpeed;

        public float TrackedImageMoveSpeedMultiplier => _trackedImageMoveSpeedMultiplier;

        [SerializeField]
        private float _moveSpeed;

        [SerializeField]
        private float _trackedImageMoveSpeedMultiplier;
    }
}