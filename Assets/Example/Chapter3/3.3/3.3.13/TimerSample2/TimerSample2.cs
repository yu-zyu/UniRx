using System;
using UniRx;
using UnityEngine;

namespace Samples.Section3.FactoryMethods
{
    public class TimerSample2 : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            //1秒待ってから0.5秒ごとにメッセージを発行する　Observable
            var timer = Observable.Timer(
                dueTime: TimeSpan.FromSeconds(1),
                period: TimeSpan.FromSeconds(0.5));

            Debug.Log("Subscribeした時刻：" + Time.time);

            timer.Subscribe(
                x => Debug.Log($"[{x}]:{Time.time}"),
                () => Debug.Log("OnCompleted")
                ).AddTo(this); //Dispose()の実行を忘れない
        }
    }
}
