using System;
using System.Threading;
using UniRx;
using UnityEngine;

namespace Samples.Section2.Schedulers
{
    public class TimersSample : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            //MainThreadを指定
            //「1秒経過直後に実行されたUpdate()」と同じタイミングに実行される
            Observable.Timer(TimeSpan.FromSeconds(1), Scheduler.MainThread)
                .Subscribe(x => Debug.Log("1秒経過しました"))
                .AddTo(this);

            //未指定の場合はMainThreadScheduker指定と同じになる
            Observable.Timer(TimeSpan.FromSeconds(1))
                .Subscribe(x => Debug.Log("1秒経過しました"))
                .AddTo(this);

            //MainThreadEndFrame指定時
            //　「1秒経過直後のフレームのレンダリング後」に実行される
            Observable.Timer(TimeSpan.FromSeconds(1), Scheduler.MainThreadEndOfFrame)
                .Subscribe(x => Debug.Log("1秒経過しました"))
                .AddTo(this);

            //CurentThreadを指定するとそのまま同じスレッドで処理を実行する
            //このコードの場合は新しく作ったスレッド上でタイマのカウントを実行する
            new Thread(() =>
            {
                Observable.Timer(TimeSpan.FromSeconds(1), Scheduler.CurrentThread)
                  .Subscribe(x => Debug.Log("1秒経過しました"))
                  .AddTo(this);
            }).Start();
        }
    }
}
