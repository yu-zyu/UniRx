using System;
using UniRx;
using UnityEngine;

namespace Samples.Section2.Schedulers
{
    public class CompareSchedulers : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            //Unityのコルーチンを用いて3秒計測してくれる（メインスレッドをブロックしない）
            Observable
                .Timer(TimeSpan.FromSeconds(3), Scheduler.MainThread)
                .Subscribe(x => Debug.Log("a"))
                .AddTo(this);

            //メインスレッドをThread.Sleepして3秒計測
            Observable
                .Timer(TimeSpan.FromSeconds(3), Scheduler.CurrentThread)
                .Subscribe(x => Debug.Log("b"))
                .AddTo(this);
        }
    }
}
