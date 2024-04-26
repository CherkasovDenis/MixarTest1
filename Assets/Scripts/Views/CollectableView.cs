using System;
using UnityEngine;

namespace MixarTest1.Views
{
    [RequireComponent(typeof(Rigidbody))]
    public class CollectableView : View
    {
        public event Action Triggered;

        [SerializeField]
        private string _targetTag;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(_targetTag))
            {
                Triggered?.Invoke();
            }
        }
    }
}