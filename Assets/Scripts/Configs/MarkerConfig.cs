using UnityEngine;

namespace MixarTest1.Configs
{
    [CreateAssetMenu(fileName = nameof(MarkerConfig), menuName = Constants.ConfigMenuPath + nameof(MarkerConfig))]
    public class MarkerConfig : ScriptableObject
    {
        public string MarkerImageUrl => _markerImageUrl;

        [SerializeField]
        private string _markerImageUrl;
    }
}