using System;
using System.Threading;
using UniRx;
using Cysharp.Threading.Tasks;

using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace Samples.Section1.Async
{
    //指定のURIからテクスチャをダウンロードして
    //RawImageに設定する
    public class DownloadTextureUniTask : MonoBehaviour
    {
        [SerializeField] private RawImage _rawImage;

        // Start is called before the first frame update
        void Start()
        {
            //このGameObjectに紐付いたCancellationTokenを取得
            var token = this.GetCancellationTokenOnDestroy();

            //テクスチャのセットアップを実行
            SetupTextureAsync(token).Forget();
        }

        private async UniTaskVoid SetupTextureAsync(CancellationToken token)
        {
            try
            {
                var uri = "https://magical-iga-blog-album232241-dev.s3.ap-northeast-1.amazonaws.com/public/magicaligaBlog.png";

                //UniRxのRetryを使いたいので、UniTaskからObservableへ変換する
                var observable = Observable
                    .Defer(() =>
                    {
                        //UniTask -> IObservable
                        return GetTextureAsync(uri, token)
                          .ToObservable();
                    })
                .Retry(3);

                //Observableもawaitで待ち受けが可能
                var texture = await observable;

                _rawImage.texture = texture;
            }
            catch(Exception e) when(!(e is OperationCanceledException))
            {
                Debug.LogError(e);
            }
        }

        //コルーチンの代わりにasync/awaitを利用する
        private async UniTask<Texture> GetTextureAsync(
            string uri,
            CancellationToken token)
        {
            using(var uwr = UnityWebRequestTexture.GetTexture(uri))
            {
                await uwr.SendWebRequest().WithCancellation(token);
                return ((DownloadHandlerTexture)uwr.downloadHandler).texture;
            } 

        }
    }
}

