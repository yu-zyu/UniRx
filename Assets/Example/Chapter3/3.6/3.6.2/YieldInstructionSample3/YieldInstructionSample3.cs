using System;
using System.Collections;
using System.IO;
using UniRx;
using UnityEngine;

namespace Samples.Section3.Coroutines
{
    public class YieldInstructionSample3 : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(ReadFileCoroutine());
        }

        //Fileの非同期読み込みをコル－チンで待ち受ける
        private IEnumerator ReadFileCoroutine()
        {
            //ファイルの非同期読み込みをYieldInstructionに変換する
            //throwOnErrorにfalseを指定すると、
            //失敗時の例外を保持してくれるようになる
            //(trueの場合は例外がそのままthrowされる)
            var yi = ReadFileAsync(@"data.txt")
                .ToYieldInstruction(throwOnError: false);

            //待機
            yield return yi;

            if(yi.HasError) // HasErrorで成否の判定ができる
            {
                //OnError時のExceptionはErrorに格納される
                Debug.LogError(yi.Error);
            }
            else
            {
                //成功時の結果はResultに格納される
                Debug.Log(yi.Result);
            }
        }

        //非同期でファイルを読み込むIObservableを作成する
        private IObservable<string> ReadFileAsync(string path)
        {
            return Observable.Start(() =>
            {
                using (var r = new StreamReader(path))
                {
                    return r.ReadToEnd();
                }
            }, Scheduler.ThreadPool);
        }
    }
}
