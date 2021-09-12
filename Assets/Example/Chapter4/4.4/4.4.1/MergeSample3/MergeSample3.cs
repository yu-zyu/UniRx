using System;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace Samples.Section4.Synthesizers
{
    public class MergeSample3 : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            IEnumerable<IObservable<int>> streams = new[]
            {
                Observable.Range(100, 3),
                Observable.Range(200, 3),
                Observable.Range(300, 3),
            };

            streams
                .Merge() // 配列内のObservableを1つのObservableにまとめる
                .Subscribe(x => Debug.Log(x));
        }
    }
}
