using System;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

namespace MixarTest1.Views
{
    public class View : MonoBehaviour
    {
        public event Action Tap;

        public event Action LongTap;

        public ARPlane ARPlane { get; private set; }

        public void OnTap()
        {
            Tap?.Invoke();
        }

        public void OnLongTap()
        {
            LongTap?.Invoke();
        }

        public void SetARPlane(ARPlane arPlane)
        {
            ARPlane = arPlane;
        }
    }
}