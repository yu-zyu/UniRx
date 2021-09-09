using System;
using UniRx;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace Samples.Section3.FactoryMethods
{
    public class UnityWebRequestToObservable : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            //UniTaskからObservableに変換できる
            FetchAsync("https://magical-iga.com/")
                .ToObservable()
                .Subscribe(x => Debug.Log(x));

        }

        //HTTP通信をUnityWebRequestで行う
        private async UniTask<string> FetchAsync(string uri)
        {
            using(var uwr = UnityWebRequest.Get(uri))
            {
                //UniTaskを導入した場合はawaitできる
                await uwr.SendWebRequest();
                return uwr.downloadHandler.text;
            }

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
