using System;
using UnityEngine;

namespace MixarTest1.Models
{
    public class MarkerModel
    {
        public event Action UpdatedTexture;

        public Texture2D MarkerTexture { get; private set; }

        public void SetMarkerTexture(Texture2D texture2D)
        {
            MarkerTexture = texture2D;
            UpdatedTexture?.Invoke();
        }
    }
}