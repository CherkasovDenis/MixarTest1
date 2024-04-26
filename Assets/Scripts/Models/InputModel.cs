using System;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

namespace MixarTest1.Models
{
    public class InputModel
    {
        public event Action<ARPlane, Vector3> TapOnPlane;

        public void OnTapOnPlane(ARPlane arPlane, Vector3 position)
        {
            TapOnPlane?.Invoke(arPlane, position);
        }
    }
}