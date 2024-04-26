using UnityEngine;

namespace MixarTest1.Configs
{
    [CreateAssetMenu(fileName = nameof(CollectablesSpawnConfig),
        menuName = Constants.ConfigMenuPath + nameof(CollectablesSpawnConfig))]
    public class CollectablesSpawnConfig : ScriptableObject
    {
        public int MinSpawnCount => _minSpawnCount;

        public int MaxSpawnCount => _maxSpawnCount;

        public Vector2 SpawnRadiusRange => _spawnRadiusRange;

        [SerializeField]
        private int _minSpawnCount;

        [SerializeField]
        private int _maxSpawnCount;

        [SerializeField]
        private Vector2 _spawnRadiusRange;
    }
}