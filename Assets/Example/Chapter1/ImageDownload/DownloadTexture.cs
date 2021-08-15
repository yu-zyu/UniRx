using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace Samples.Section1
{

    public class DownloadTexture : MonoBehaviour
    {
        //uGUIのRawImage
        [SerializeField] private RawImage _rawImage;

        // Start is called before the first frame update
        void Start()
        {
            var uri = "https://magical-iga-blog-album232241-dev.s3.ap-northeast-1.amazonaws.com/public/magicaligaBlog.png";

            //テクスチャを取得する
            //ただし例外発生時は系3回まで試行する

            GetTextureAsync(uri)
                .OnErrorRetry(
                onError: (Exception _) => { },
                retryCount: 3
                ).Subscribe(
                result => { _rawImage.texture = result; },
                error => { Debug.LogError(error); }
                ).AddTo(this);
        }

        //コールーチンを起動して、その結果をObservableで返す
        private IObservable<Texture> GetTextureAsync(string uri)
        {
            return Observable
                .FromCoroutine<Texture>(observer =>
                {
                    return GetTextureCoroutine(observer, uri);
                });
        }

        //コルーチンでテクスチャをダウンロードする
        private IEnumerator GetTextureCoroutine(IObserver<Texture> observer, string uri)
        {
            using(var uwr = UnityWebRequestTexture.GetTexture(uri))
            {
                yield return uwr.SendWebRequest();
                if(uwr.isNetworkError || uwr.isHttpError)
                {
                    //エラーが起きたらOnErrorメッセージを発行する
                    observer.OnError(new Exception(uwr.error));
                    yield break;
                }

                var result = ((DownloadHandlerTexture)uwr.downloadHandler).texture;
                //成功したらOnNext/OnCompletedメッセージを発行する
                observer.OnNext(result);
                observer.OnCompleted();
            }
        }
    }
}

