using System;
using UniRx;
using UnityEngine;

namespace Samples.Section4.Synthesizers
{
    public class MergeSample2 : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            //Observableを扱う Observable
            IObservable<IObservable<int>> streams =
                Observable.Range(1, 3, Scheduler.Immediate)
                .Select(x =>
                {
                    return Observable.Range(x * 100, 3, Scheduler.Immediate);
                });
            streams
                .Merge() // 1つのObservableにまとめる
                .Subscribe(x => Debug.Log(x));
        }
    }
}
