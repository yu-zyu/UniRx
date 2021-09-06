using System;
using System.Collections;
using UniRx;
using UnityEngine;

namespace Samples.Section3.Subjects.Async
{
    //ゲームのリソースを読み込んで管理する
    public class GameResourceProvider : MonoBehaviour
    {
        //プレイヤのテクスチャ情報を扱うAsyncSubject
        private readonly AsyncSubject<Texture> _playerTextureAsyncSubject = new AsyncSubject<Texture>();

        //プレイヤのテクスチャ情報
        public IObservable<Texture> PlayerTextureAsync => _playerTextureAsyncSubject;

        // Start is called before the first frame update
        void Start()
        {
            //起動時にテクスチャをロードする
            StartCoroutine(LoadTexture());
        }

        //テクスチャを読み込むコルーチン
        private IEnumerator LoadTexture()
        {
            //プレイヤのテクスチャを非同期で読み込み
            var resource = Resources.LoadAsync<Texture>("Textures/player");

            yield return resource;

            //読み込みが完了したらAsyncSubjectで結果を通知する
            _playerTextureAsyncSubject.OnNext(resource.asset as Texture);
            _playerTextureAsyncSubject.OnCompleted();
        }
    }
}
