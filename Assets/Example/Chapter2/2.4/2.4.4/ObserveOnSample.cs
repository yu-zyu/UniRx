﻿using System.IO;
using System.Threading.Tasks;
using UniRx;
using UnityEngine;

namespace Sample.Section2.Schedulers
{
    public class ObserveOnSample : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            //ファイルをスレッドプール上で読み込む処理
            var task = Task.Run(() => File.ReadAllText(@"data.txt"));

            //Task -> Observable変換
            //このときの実行コンテキストはスレッドプールのまま
            task.ToObservable()
                //実行コンテキストをメインスレッドに切り替える
                .ObserveOn(Scheduler.MainThread)
                .Subscribe(x =>
                {
                    //ここに到達した時点で実行コンテキストは
                    // メインスレッドに切り替わってる
                    Debug.Log(x);
                });
        }
    }
}
