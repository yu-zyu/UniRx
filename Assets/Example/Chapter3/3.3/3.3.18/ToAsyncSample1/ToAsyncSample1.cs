using System;
using System.IO;
using UniRx;
using UnityEngine;

namespace Samples.Section3.FactoryMethods
{
    public class ToAsyncSample1 : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            //Observable.ToAsyncの返り値はFunc<IObservable<T>>
            Func<IObservable<string>> fileReadFunc;

            //スレッドプール上でファイルを読み込む処理を実行する
            fileReadFunc = Observable.ToAsync(() =>
            {
                using (var r = new StreamReader(@"data.txt"))
                {
                    //読み取り結果をObservableに流す
                    return r.ReadToEnd();
                }
            }, Scheduler.ThreadPool);

            //非同期処理を開始する為には明示的にメソッドを呼び出しする必要がある
            fileReadFunc().Subscribe(x => Debug.Log(x));

            //Invoke()でもよい
            //fileReadFunc.Invoke().Subscribe();
        }
    }
}
