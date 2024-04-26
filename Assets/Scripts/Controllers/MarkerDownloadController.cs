using System.Threading;
using Cysharp.Threading.Tasks;
using MixarTest1.Configs;
using MixarTest1.Models;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.XR.ARFoundation;
using VContainer.Unity;

namespace MixarTest1.Controllers
{
    public class MarkerDownloadController : IAsyncStartable
    {
        private readonly MarkerConfig _markerConfig;
        private readonly MarkerModel _markerModel;

        public MarkerDownloadController(MarkerConfig markerConfig, MarkerModel markerModel)
        {
            _markerConfig = markerConfig;
            _markerModel = markerModel;
        }

        public async UniTask StartAsync(CancellationToken cancellation)
        {
            await UniTask.WaitUntil(() =>
                ARSession.state == ARSessionState.SessionInitializing ||
                ARSession.state == ARSessionState.SessionTracking, cancellationToken: cancellation);

            var markerRequest = UnityWebRequestTexture.GetTexture(_markerConfig.MarkerImageUrl);

            await markerRequest.SendWebRequest().WithCancellation(cancellation);

            _markerModel.SetMarkerTexture(DownloadHandlerTexture.GetContent(markerRequest));
            
            Debug.Log("Downloaded");
        }
    }
}