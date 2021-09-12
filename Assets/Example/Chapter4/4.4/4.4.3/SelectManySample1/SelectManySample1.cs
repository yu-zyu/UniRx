using System;
using UniRx;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace Samples.Section4.Synthesizers
{
    public class SelectManySample1 : MonoBehaviour
    {
        //ダウンロードボタン
        [SerializeField] private Button _downloadButton;

        //URI入力欄
        [SerializeField] private InputField _uriInputField;

        // Start is called before the first frame update
        void Start()
        {
            //uGUIのボタンがクリックされたら、指定のURIにたいしてHTTP通信を行う
            _downloadButton.OnClickAsObservable()
                .Select(_ => _uriInputField.text) // 入力されたURIを取得
                .SelectMany(uri => FetchAsync(uri).ToObservable()) //指定URIに通信する
                .Subscribe(x => Debug.Log(x));
        }

        //UniTaskを使ってサーバ通信
        private async UniTask<string> FetchAsync(string uri)
        {
            using(var uwr = UnityWebRequest.Get(uri))
            {
                await uwr.SendWebRequest();
                return uwr.downloadHandler.text;
            }
        }
    }
}
