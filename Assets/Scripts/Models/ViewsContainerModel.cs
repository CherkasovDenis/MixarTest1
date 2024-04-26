using System;
using System.Collections.Generic;
using MixarTest1.Views;
using UnityEngine;

namespace MixarTest1.Models
{
    public abstract class ViewsContainerModel<T> where T : MonoBehaviour
    {
        public event Action<T> Added;

        public event Action<T> Removed;

        public event Action RemovedAll;

        public List<T> Views { get; } = new List<T>();

        public void Add(T view)
        {
            Views.Add(view);
            Added?.Invoke(view);
        }

        public void Remove(T movableView)
        {
            Views.Remove(movableView);
            Removed?.Invoke(movableView);

            if (Views.Count == 0)
            {
                RemovedAll?.Invoke();
            }
        }
    }

    public class MovablesModel : ViewsContainerModel<MovableView> { }

    public class CollectablesModel : ViewsContainerModel<CollectableView> { }
}